using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Domain.Models;

namespace SOHome.Domain.MapperProfiles
{
    public class UserGroupProfile : Profile
    {
        public UserGroupProfile()
        {
            CreateMap<UserGroup, UserGroupModel>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
