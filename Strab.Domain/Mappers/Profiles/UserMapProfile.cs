using AutoMapper;
using Strab.Domain.Dtos;
using Strab.Domain.Entities;

namespace Strab.Domain.Mappers.Profiles;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<User, UserDTO>().ForMember(dst => dst.Role, map => map.MapFrom(src => src.Role.Name));
    }
}