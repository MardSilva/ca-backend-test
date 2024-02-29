using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CA.BackendTest.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}