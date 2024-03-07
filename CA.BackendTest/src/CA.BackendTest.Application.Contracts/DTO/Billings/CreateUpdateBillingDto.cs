using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CA.BackendTest.DTO.Billings
{
    public class CreateUpdateBillingDto
    {
        [Required]
        [StringLength(50)]
        public string InvoiceNumber { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        public List<CreateUpdateBillingLineDto> Lines { get; set; } = new List<CreateUpdateBillingLineDto>();
    }
}