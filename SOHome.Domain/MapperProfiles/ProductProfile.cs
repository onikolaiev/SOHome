using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;

namespace SOHome.Domain.MapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();

            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.Code, map => map.Ignore());
        }
    }
}
