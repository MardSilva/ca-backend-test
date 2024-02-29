using CA.BackendTest.DTO.Customers;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CA.BackendTest.Interfaces
{
    public interface ICustomerAppService : ICrudAppService<CustomerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCustomerDto>
    {
    }
}