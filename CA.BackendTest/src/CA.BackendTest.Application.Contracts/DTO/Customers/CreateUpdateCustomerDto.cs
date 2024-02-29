using System.ComponentModel.DataAnnotations;

namespace CA.BackendTest.DTO.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}