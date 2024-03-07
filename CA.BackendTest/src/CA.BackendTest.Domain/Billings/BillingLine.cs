using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CA.BackendTest.Billings
{
    public class BillingLine : AuditedEntity<Guid>
    {
        public Guid BillingId { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
        public Billing Billing { get; set; }
    }
}