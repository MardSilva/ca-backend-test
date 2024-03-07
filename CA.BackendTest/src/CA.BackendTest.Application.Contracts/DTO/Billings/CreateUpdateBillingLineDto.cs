using System;
using System.ComponentModel.DataAnnotations;

namespace CA.BackendTest.DTO.Billings
{
    public class CreateUpdateBillingLineDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }
}