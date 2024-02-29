using AutoMapper;
using CA.BackendTest.Customers;
using CA.BackendTest.DTO.Customers;

namespace CA.BackendTest.Mapping
{
    public class CustomerApplicationAutoMapperProfile : Profile
    {
        public CustomerApplicationAutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CreateUpdateCustomerDto, Customer>().ReverseMap();
        }
    }
}