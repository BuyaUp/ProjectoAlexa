using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Newtonsoft.Json;

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
            var questionarios = QuestionarioRepositorio.BuscarTodos();

            return View(questionarios);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            var questionaTemp = new Questionario();
            var areas = AreaCandidaturaRepositorio.BuscarTodas();

            if (id == null || id == 0)
            {
                var contaQuest = QuestionarioRepositorio.BuscarTodos().Count;

                questionaTemp = new Questionario
                {
                    AreaCandidaturaId = areas[0].Id,
                    Titulo = string.Format("Questionário {0}", contaQuest++),
                    UsuarioId = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name).Id,
                    DataCadastro = DateTime.Now,
                    Ativo = true
                };

                var questId = QuestionarioRepositorio.Salvar(questionaTemp);
                questionaTemp = QuestionarioRepositorio.BuscarPeloId(questId);
            }
            else
                questionaTemp = QuestionarioRepositorio.BuscarPeloId(id);

            ViewBag.QuestionarioId = questionaTemp.Id;
            ViewBag.UsuarioId = questionaTemp.UsuarioId;
            ViewBag.AreaCandidaturas = areas;
            ViewBag.TotalPerguntas = questionaTemp.TotalPerguntas();
            return View(questionaTemp);
        }

        [HttpPost]
        public ActionResult Create(Questionario questionario)
        {
            if (ModelState.IsValid)
            {
                //Falta mudar o estado de InDesign Para Published
                QuestionarioRepositorio.Salvar(questionario);

                return RedirectToAction("Index");
            }

            var areas = AreaCandidaturaRepositorio.BuscarTodas();

            ViewBag.QuestionarioId = questionario.Id;
            ViewBag.AreaCandidaturas = areas;
            return View(questionario);
        }

        public JsonResult AddPergunta(PerguntaViewModel pergunta, List<RespostaViewModel> respostas)
        {
            pergunta.Respostas = respostas;

            var perguntaId = PerguntaRepositorio.Salvar(Mapper.Map<Pergunta>(pergunta));

            var questionario = QuestionarioRepositorio.BuscarPeloId(pergunta.QuestionarioId);
            var totalPerguntas = questionario.TotalPerguntas();
            var listaPerguntas = questionario.Perguntas
                                .Select(p => new PerguntaViewModel
                                {
                                    QuestionarioId = p.QuestionarioId,
                                    PerguntaId = p.Id,
                                    Descricao = p.Descricao,
                                    Pontos = p.Pontos,
                                    TotalRespostas = p.TotalRespostas(),
                                    Respostas = null
                                }).ToList();

            return Json(new { perguntaId, totalPerguntas, perguntas = listaPerguntas }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult BuscaPerguntaPorId(int id)
        {
            var pergunta = PerguntaRepositorio.BuscarPeloId(id);

            string value = JsonConvert.SerializeObject(pergunta, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            if (pergunta != null)
            {
                var totalRespost = pergunta.TotalRespostas();
                var respost = pergunta.Respostas.ToList();
                respost.ForEach(p => p.Pergunta = null);

                return Json(new { pergunta = value, respostas = respost, totalRespostas = totalRespost }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { sucesso = false });
        }

        [HttpPost]
        public JsonResult EliminarPergunta(int id)
        {
            var pergunta = PerguntaRepositorio.BuscarPeloId(id);

            if (pergunta != null)
            {
                bool ret = PerguntaRepositorio.Eliminar(pergunta);

                return Json(new { sucesso = ret });
            }

            return Json(new { sucesso = false });
        }

    }
}