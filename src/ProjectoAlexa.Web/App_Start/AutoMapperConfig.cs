using AutoMapper;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Web.ViewModels;

namespace ProjectoAlexa
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistarViewModel, Usuario>()
                .ForMember(to => to.Id, src => src.MapFrom(x => x.Id))
                .ForMember(to => to.UsuarioPerfilId, src => src.MapFrom(x => x.UsuarioPerfilId))
                .ReverseMap();

            });

            Mapper = config.CreateMapper();
        }
    }
}
