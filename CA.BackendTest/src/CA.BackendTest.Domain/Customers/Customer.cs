using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace CA.BackendTest.Customers
{
    public class Customer : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}