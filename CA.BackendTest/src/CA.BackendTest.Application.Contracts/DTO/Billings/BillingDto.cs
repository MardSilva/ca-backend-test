using CA.BackendTest.DTO.Customers;
using System;
using System.Collections.Generic;

namespace CA.BackendTest.DTO.Billings
{
    public class BillingDto
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