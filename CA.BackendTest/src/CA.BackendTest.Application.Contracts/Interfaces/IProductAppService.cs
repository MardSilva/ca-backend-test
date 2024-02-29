using CA.BackendTest.DTO.Products;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CA.BackendTest.Interfaces
{
    public interface IProductAppService : ICrudAppService<ProductDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProductDto>
    {
    }
}