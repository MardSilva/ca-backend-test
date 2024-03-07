using AutoMapper;
using CA.BackendTest.Billings;
using CA.BackendTest.DTO.Billings;

namespace CA.BackendTest.Mapping
{
    public class BillingApplicationAutoMapperProfile : Profile
    {
        public BillingApplicationAutoMapperProfile()
        {
            CreateMap<Billing, BillingDto>().ReverseMap();
            CreateMap<BillingLine, BillingLineDto>().ReverseMap();
            CreateMap<CreateUpdateBillingDto, Billing>().ReverseMap();
            CreateMap<CreateUpdateBillingLineDto, BillingLine>().ReverseMap();
        }
    }
}