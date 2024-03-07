using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace CA.BackendTest.Billings
{
    public class Billing : AuditedAggregateRoot<Guid>
    {
        public string InvoiceNumber { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }

        public ICollection<BillingLine> Lines { get; private set; }

        public Billing()
        {
            Lines = new List<BillingLine>();
        }
    }
}