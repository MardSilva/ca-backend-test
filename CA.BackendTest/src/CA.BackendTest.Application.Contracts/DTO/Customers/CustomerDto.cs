using System;
using Volo.Abp.Application.Dtos;

namespace CA.BackendTest.DTO.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}