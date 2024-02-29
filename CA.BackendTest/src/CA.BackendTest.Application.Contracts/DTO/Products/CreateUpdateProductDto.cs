using System.ComponentModel.DataAnnotations;

namespace CA.BackendTest.DTO.Products
{
    public class CreateUpdateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Subtotal { get; set; }
    }
}