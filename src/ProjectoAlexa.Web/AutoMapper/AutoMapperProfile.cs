using AutoMapper;
using ProjectoAlexa.Web.Models;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegistarViewModel, UsuarioModel>();
        }
    }
}
