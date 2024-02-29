using AutoMapper;
using CA.BackendTest.DTO.Products;
using CA.BackendTest.Products;

namespace CA.BackendTest.Mapping
{
    public class ProductApplicationAutoMapperProfile : Profile
    {
        public ProductApplicationAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CreateUpdateProductDto, Product>().ReverseMap();
        }
    }
}