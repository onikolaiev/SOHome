using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;
using SOHome.Domain.Services;

namespace SOHome.Domain.MapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, RegisterModel>()
                .ForMember(dest => dest.Username, map => map.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.Code));

            CreateMap<RegisterModel, User>()
                .ForMember(dest => dest.UserName, map => map.MapFrom(src => src.Username))
                .ForMember(dest => dest.Code, map => map.Ignore());

            CreateMap<Person, RegisterModel>()
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Document, map => map.MapFrom(src => src.Document))
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Person.Email))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Code, map => map.MapFrom(src => src.Code))
                .ForMember(dest => dest.Username, map => map.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Token, map => map.MapFrom(src => src.GenerateToken()));

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Code, map => map.Ignore())
                .ForMember(dest => dest.UserName, map => map.MapFrom(src => src.Username));
        }
    }
}
