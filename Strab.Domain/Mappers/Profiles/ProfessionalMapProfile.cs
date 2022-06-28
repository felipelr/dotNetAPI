using AutoMapper;
using Strab.Domain.Dtos;
using Strab.Domain.Entities;

namespace Strab.Domain.Mappers.Profiles;

public class ProfessionalMapProfile : Profile
{
    public ProfessionalMapProfile()
    {
        CreateMap<Professional, ProfessionalDTO>();
    }
}