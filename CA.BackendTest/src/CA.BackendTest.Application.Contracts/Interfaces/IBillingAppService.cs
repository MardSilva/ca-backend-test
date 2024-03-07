using CA.BackendTest.DTO.Billings;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CA.BackendTest.Interfaces
{
    public interface IBillingAppService : ICrudAppService<BillingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBillingDto>
    {
    }
}