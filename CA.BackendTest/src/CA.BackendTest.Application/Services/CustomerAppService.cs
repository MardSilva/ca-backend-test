using CA.BackendTest.Customers;
using CA.BackendTest.DTO.Billings;
using CA.BackendTest.DTO.Customers;
using CA.BackendTest.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CA.BackendTest.Services
{
    public class CustomerAppService : CrudAppService<Customer, CustomerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCustomerDto>, ICustomerAppService
    {
        private readonly BillingService _billingService;
        public CustomerAppService(IRepository<Customer, Guid> repository,
                                  BillingService billingService) : base(repository)
        {
            _billingService = billingService;
        }

        public override async Task<PagedResultDto<CustomerDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var customers = await Repository.GetListAsync();
            if (!customers.Any())
            {
                
                var billingDataResponse = await _billingService.GetBillingDataAsync();
                if (billingDataResponse.IsSuccessStatusCode)
                {
                    var billingDataString = await billingDataResponse.Content.ReadAsStringAsync();
                    var billingsJsonData = JsonConvert.DeserializeObject<List<BillingDto>>(billingDataString);

                    foreach (var billing in billingsJsonData)
                    {
                        var customer = new Customer
                        {
                            Name = billing.Customer.Name,
                            Email = billing.Customer.Email,
                            Address = billing.Customer.Address
                        };

                        await Repository.InsertAsync(customer, autoSave: true);
                    }

                    // recharging the customers list
                    customers = await Repository.GetListAsync();
                }
                else
                {
                    // Handle the case where the billing data cannot be retrieved
                    throw new Exception("Não foi possível recuperar dados de billing.");
                }
            }

            var customerDtos = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
            return new PagedResultDto<CustomerDto>(totalCount: customerDtos.Count, items: customerDtos);
        }
    }
}