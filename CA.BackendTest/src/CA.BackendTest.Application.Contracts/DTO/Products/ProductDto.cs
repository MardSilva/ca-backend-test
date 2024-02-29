using System;
using Volo.Abp.Application.Dtos;

namespace CA.BackendTest.DTO.Products
{
    public class ProductDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}