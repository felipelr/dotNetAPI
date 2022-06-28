using AutoMapper;

namespace Strab.Domain.Mappers.Interfaces;
public interface IMapperConfig
{
    IMapper GetMapper();
}