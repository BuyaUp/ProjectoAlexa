using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult UsuarioAtual()
        {
            var user = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name);

            var usuarioViewModel = Mapper.Map<UsuarioAtualViewModel>(user);

            return PartialView("~/Views/Shared/_UsuarioAtual.cshtml", usuarioViewModel);
        }

        public ActionResult Perfil()
        {
            var user = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name);

            var usuarioViewModel = Mapper.Map<UsuarioAtualViewModel>(user);

            var concursoAtual = ConcursoRepositorio.RecuperarLista()
                                .OrderByDescending(c => c.Ativo)
                                .ThenByDescending(c => c.DataCadastro)
                                .FirstOrDefault();

            var ultimaCandidatura = CandidaturaRepositorio.BuscarPeloUsuarioId(user.Id)
                                    .Where(c => c.ConcursoId == concursoAtual.Id)
                                    .OrderByDescending(c => c.DataCadastro)
                                    .FirstOrDefault();

            if (ultimaCandidatura != null)
            {
                usuarioViewModel.DataUltimaCandidatura = ultimaCandidatura.DataCadastro;
                usuarioViewModel.UltimaCandidaturaId = ultimaCandidatura.Id;
                usuarioViewModel.DataExame = ConcursoRepositorio.BuscarPeloId(ultimaCandidatura.ConcursoId).DataExames;
            }


            return View(usuarioViewModel);
        }

    }
}