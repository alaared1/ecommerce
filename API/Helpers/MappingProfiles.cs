using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, output => output.MapFrom(src => src.ProductBrand.Name))
                .ForMember(d => d.ProductType, output => output.MapFrom(src => src.ProductType.Name))
                .ForMember(d => d.PictureUrl, output => output.MapFrom<ProductUrlResolver>());
        }

    }
}