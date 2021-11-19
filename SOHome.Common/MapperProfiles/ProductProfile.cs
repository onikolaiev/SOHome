using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Common.Models;

namespace SOHome.Common.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.Code))
                .ReverseMap();
        }
    }
}
