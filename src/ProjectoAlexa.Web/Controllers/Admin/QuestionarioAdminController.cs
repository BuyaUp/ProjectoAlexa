using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using ProjectoAlexa.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers.Admin
{
    public class QuestionarioAdminController : BaseController
    {
        List<RespostaViewModel> ListaRespostas = new List<RespostaViewModel>();

        // GET: QuestionarioAdmin
        public ActionResult Index()
        {
            ListaRespostas.Add(new RespostaViewModel { Descricao = "Teste 1", PerguntaId = 1, RespostaCerta = true });
            ViewBag.Respostas = ListaRespostas;

            var questionarios = QuestionarioRepositorio.BuscarTodos();
            return View(questionarios);
        }

        public ActionResult Create()
        {
            ViewBag.AreaCandidaturas = AreaCandidaturaRepositorio.BuscarTodas();
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