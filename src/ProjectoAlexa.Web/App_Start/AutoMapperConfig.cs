using AutoMapper;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Web.ViewModels;

namespace ProjectoAlexa
{
    public class AutoMapperConfig
    {
        public static IMapper IniciarAutoMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistarViewModel, Usuario>()
                //.ForMember(to => to.Id, src => src.MapFrom(x => x.Id))
                .ForMember(to => to.UsuarioPerfilId, src => src.MapFrom(x => x.UsuarioPerfilId))
                .ReverseMap();

                cfg.CreateMap<AreaCandidaturaViewModel, AreaCandidatura>()
                .ReverseMap();

                cfg.CreateMap<CandidaturaViewModel, Candidatura>()
                .ReverseMap();

                cfg.CreateMap<ConcursoViewModel, Concurso>()
                .ReverseMap();


                cfg.CreateMap<UsuarioAtualViewModel, Usuario>()
                .ReverseMap();

                cfg.CreateMap<QuestionarioViewModel, Questionario>()
                .ReverseMap();

                cfg.CreateMap<PerguntaViewModel, Pergunta>()
                .ForMember(to => to.Id, src => src.MapFrom(x => x.PerguntaId))
                .ReverseMap();

                cfg.CreateMap<RespostaViewModel, Resposta>()
                .ReverseMap();
            });


            return config.CreateMapper();
        }
    }
}
