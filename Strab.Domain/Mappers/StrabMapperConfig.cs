using AutoMapper;
using Strab.Domain.Mappers.Interfaces;
using Strab.Domain.Mappers.Profiles;

namespace Strab.Domain.Mappers;

public class StrabMapperConfig : IMapperConfig
{
    private MapperConfiguration Configuration;
    public IMapper Mapper { get; private set; }
    public StrabMapperConfig()
    {
        Configuration = new MapperConfiguration(cfg =>
         {
             cfg.AddProfile<UserMapProfile>();
             cfg.AddProfile<ClientMapProfile>();
             cfg.AddProfile<ProfessionalMapProfile>();
         });

        Mapper = Configuration.CreateMapper();
    }

    public IMapper GetMapper()
    {
        return Mapper;
    }
}