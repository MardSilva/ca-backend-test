using CA.BackendTest.Customers;
using CA.BackendTest.DTO.Billings;
using CA.BackendTest.DTO.Customers;
using CA.BackendTest.Interfaces;
using System;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Volo.Abp;
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
    }
}