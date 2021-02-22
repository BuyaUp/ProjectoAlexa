using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

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
        public ActionResult Create(int? id)
        {
            var questionaTemp = new Questionario();
            var areas = AreaCandidaturaRepositorio.BuscarTodas();

            if (id == null || id == 0)
            {
                var ultimo = QuestionarioRepositorio.BuscarTodos()
                            .OrderByDescending(q => q.Id)
                            .FirstOrDefault().Id;

                questionaTemp = new Questionario
                {
                    AreaCandidaturaId = areas[0].Id,
                    Titulo = string.Format("Questionário {0}", ultimo),
                    UsuarioId = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name).Id,
                    DataCadastro = DateTime.Now,
                    Ativo = true
                };

                QuestionarioRepositorio.Salvar(questionaTemp);
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

        public ActionResult Editar(int id)
        {
            var quest = QuestionarioRepositorio.BuscarPeloId(id);

            if (quest != null)
                return View(quest);

            return RedirectToAction("Index");
        }

        public ActionResult AddPergunta(PerguntaViewModel pergunta, List<RespostaViewModel> respostas)
        {
            pergunta.Respostas = respostas;

            var perguntaSendDB = Mapper.Map<Pergunta>(pergunta);

            PerguntaRepositorio.Salvar(perguntaSendDB);

            return Json(pergunta, JsonRequestBehavior.AllowGet);
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