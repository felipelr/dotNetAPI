using AutoMapper;
using Strab.Domain.Dtos;
using Strab.Domain.Entities;

namespace Strab.Domain.Mappers.Profiles;

public class ClientMapProfile : Profile
{
    public ClientMapProfile()
    {
        CreateMap<Client, ClientDTO>();
    }
}