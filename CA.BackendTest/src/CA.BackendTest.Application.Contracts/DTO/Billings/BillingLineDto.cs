using System;

namespace CA.BackendTest.DTO.Billings
{
    public class BillingLineDto
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}