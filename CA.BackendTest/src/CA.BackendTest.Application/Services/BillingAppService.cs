using CA.BackendTest.Billings;
using CA.BackendTest.Customers;
using CA.BackendTest.DTO.Billings;
using CA.BackendTest.Interfaces;
using CA.BackendTest.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CA.BackendTest.Services
{
    public class BillingAppService : CrudAppService<Billing, BillingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBillingDto>, IBillingAppService
    {
        private readonly IRepository<Billing, Guid> _billingRepository;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly BillingService _billingService;

        public BillingAppService(
            IRepository<Billing, Guid> billingRepository,
            IRepository<Customer, Guid> customerRepository,
            IRepository<Product, Guid> productRepository,
            BillingService billingService)
            : base(billingRepository)
        {
            _billingRepository = billingRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _billingService = billingService;
        }

        public override async Task<PagedResultDto<BillingDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            // consuming external billing data
            var httpResponse = await _billingService.GetBillingDataAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new BusinessException("Falha ao obter dados de faturamento externos.");
            }

            var billingDataString = await httpResponse.Content.ReadAsStringAsync();
            var externalBillings = JsonConvert.DeserializeObject<List<BillingDto>>(billingDataString);

            var insertedBillings = new List<Billing>();

            foreach (var billingDto in externalBillings)
            {
                var customerExists = await _customerRepository.AnyAsync(c => c.Name == billingDto.Customer.Name);
                var allProductsExist = true;
                
                foreach (var line in billingDto.Lines)
                {
                    var productExists = await _productRepository.AnyAsync(p => p.Description == line.Description);
                    if (!productExists)
                    {
                        allProductsExist = false;
                        break; // if an product does not exist, there is no need to keep checking the others
                    }
                }

                // otherwise, if the customer exists and all products exist
                if (customerExists && allProductsExist)
                {
                    // transform the BillingDto into a Billing entity
                    var billing = ObjectMapper.Map<BillingDto, Billing>(billingDto);

                    // insert the billing
                    insertedBillings.Add(billing);
                }
            }

            // insert the billings
            await _billingRepository.InsertManyAsync(insertedBillings, autoSave: true);

            // map the inserted billings to BillingDto
            var insertedBillingDtos = ObjectMapper.Map<List<Billing>, List<BillingDto>>(insertedBillings);

            // return the inserted billings
            return new PagedResultDto<BillingDto>(totalCount: insertedBillingDtos.Count, items: insertedBillingDtos);
        }


        public override async Task<BillingDto> CreateAsync(CreateUpdateBillingDto input)
        {
            // consuming external billing data
            var httpResponse = await _billingService.GetBillingDataAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new BusinessException("Falha ao obter dados de faturamento externos.");
            }

            var billingDataString = await httpResponse.Content.ReadAsStringAsync();
            var externalBillings = JsonConvert.DeserializeObject<List<BillingDto>>(billingDataString);

            // finding the billing that matches the input
            var matchingBilling = externalBillings.FirstOrDefault(eb => eb.InvoiceNumber == input.InvoiceNumber);
            if (matchingBilling == null)
            {
                throw new BusinessException("Nenhum registro de faturamento externo correspondente encontrado.");
            }

            // checking if the customer exists
            var customerExists = await _customerRepository.AnyAsync(c => c.Id == matchingBilling.Customer.Id);
            if (!customerExists)
            {
                throw new BusinessException("Cliente especificado não existe.");
            }

            // checking if the products exist
            foreach (var line in matchingBilling.Lines)
            {
                var productExists = await _productRepository.AnyAsync(p => p.Id == line.ProductId);
                if (!productExists)
                {
                    throw new BusinessException($"Produto com ID {line.ProductId} não existe.");
                }
            }

            // mapping the input to a Billing entity
            var billing = ObjectMapper.Map<CreateUpdateBillingDto, Billing>(input);

            // inserting the billing
            await _billingRepository.InsertAsync(billing, autoSave: true);

            // mapping the billing to a BillingDto and returning it
            return ObjectMapper.Map<Billing, BillingDto>(billing);
        }


        // methods for custom logic
        public async Task<BillingDto> InsertBillingAndLinesAsync(CreateUpdateBillingDto input)
        {
            var billing = ObjectMapper.Map<CreateUpdateBillingDto, Billing>(input);

            // logic to retrieve billing and billing lines
            return ObjectMapper.Map<Billing, BillingDto>(await _billingRepository.InsertAsync(billing, autoSave: true));
        }
    }
}