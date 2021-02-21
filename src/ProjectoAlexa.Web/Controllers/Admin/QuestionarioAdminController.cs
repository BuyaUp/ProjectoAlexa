using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers.Admin
{
    [Authorize]
    public class QuestionarioAdminController : BaseController
    {
        List<RespostaViewModel> ListaRespostas = new List<RespostaViewModel>();

        public QuestionarioAdminController()
        {

        }

        // GET: QuestionarioAdmin
        public ActionResult Index()
        {
            ListaRespostas.Add(new RespostaViewModel { Descricao = "Teste 1", PerguntaId = 1, RespostaCerta = true });
            ViewBag.Respostas = ListaRespostas;

            var questionarios = QuestionarioRepositorio.BuscarTodos();
            return View(questionarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var areas = AreaCandidaturaRepositorio.BuscarTodas();
            var questionaTemp = new Questionario
            {
                AreaCandidaturaId = areas[0].Id,
                Titulo = string.Empty,
                UsuarioId = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name).Id,
                DataCadastro = DateTime.Now,
                Ativo = false
            };

            ViewBag.QuestionarioId = QuestionarioRepositorio.Salvar(questionaTemp);
            ViewBag.AreaCandidaturas = areas;
            return View();
        }

        public JsonResult AddResposta(RespostaViewModel resposta)
        {
            resposta.RespostaCerta = true;
            resposta.PerguntaId = 1;
            ListaRespostas.Add(resposta);
            return Json(resposta.Descricao, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRespostas()
        {

            return Json(ListaRespostas, JsonRequestBehavior.AllowGet);
        }
    }
}