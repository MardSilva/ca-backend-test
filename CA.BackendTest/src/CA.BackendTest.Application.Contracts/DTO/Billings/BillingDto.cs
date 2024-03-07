using CA.BackendTest.DTO.Customers;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace CA.BackendTest.DTO.Billings
{
    public class BillingDto : AuditedEntityDto<Guid>
    {
        public string InvoiceNumber { get; set; }
        public CustomerDto Customer { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public List<BillingLineDto> Lines { get; set; }
    }
}