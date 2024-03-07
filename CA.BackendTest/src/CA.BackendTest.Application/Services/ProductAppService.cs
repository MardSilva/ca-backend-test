using CA.BackendTest.DTO.Billings;
using CA.BackendTest.DTO.Products;
using CA.BackendTest.Interfaces;
using CA.BackendTest.Products;
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
    public class ProductAppService : CrudAppService<Product, ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto>, IProductAppService
    {
        private readonly BillingService _billingService;
        public ProductAppService(IRepository<Product, Guid> repository, 
                                 BillingService billingService) : base(repository)
        {
            _billingService = billingService;
        }

        public override async Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var products = await Repository.GetListAsync();

            if (!products.Any())
            {
                var billingDataResponse = await _billingService.GetBillingDataAsync();
                if (billingDataResponse.IsSuccessStatusCode)
                {
                    var billingDataString = await billingDataResponse.Content.ReadAsStringAsync();
                    var billingsJsonData = JsonConvert.DeserializeObject<List<BillingDto>>(billingDataString);

                    foreach (var billing in billingsJsonData)
                    {
                        foreach(var billingProduct in billing.Lines)
                        {
                            var newProduct = new Product
                            {
                                Name = billingProduct.Description,
                                Description = billingProduct.Description,
                                UnitPrice = billingProduct.UnitPrice,
                                Subtotal = billingProduct.Subtotal
                            };

                            await Repository.InsertAsync(newProduct, autoSave: true);
                        }
                    }

                    // recharging the products list
                    products = await Repository.GetListAsync();
                }
                else
                {
                    // Handle the case where the billing data cannot be retrieved
                    throw new Exception("Não foi possível recuperar dados de billing.");
                }
            }

            var productDtos = ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
            return new PagedResultDto<ProductDto>(products.Count, productDtos);
        }   
    }
}