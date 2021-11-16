using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;

namespace SOHome.Domain.MapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, RegisterModel>()
                .ForMember(dest => dest.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, map => map.MapFrom(src => src.Password))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.Code))
                .ReverseMap();

            CreateMap<Person, RegisterModel>()
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Document, map => map.MapFrom(src => src.Document))
                .ReverseMap();
        }
    }
}
