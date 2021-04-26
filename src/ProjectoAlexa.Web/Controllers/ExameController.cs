using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class ExameController : Controller
    {
        ProjectoBaseDataContext db = new ProjectoBaseDataContext();

        // GET: Exame
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FazerExame(string IdCandidatura)
        {
            var candidatura = CandidaturaRepositorio.BuscarPeloId(IdCandidatura);
            var questionario = QuestionarioRepositorio.BuscarTodos().Where(q => q.AreaCandidaturaId == candidatura.AreaCandidaturaId).FirstOrDefault();

            Exame exame;
            exame = new Exame {
                Ativo = true,
                CandidaturaId = candidatura.Id,
                QuestionarioId = questionario.Id,
                Resultado = 0,
            };

            db.Exames.Add(exame);
            db.SaveChanges();


            ViewBag.ExameId = exame.Id;

            if (questionario == null)
            {
                ViewBag.Mensagem = "Erro ao realizar exame, verifique o estado da sua candidatura!";

                return View();
            }

            return View(questionario);
           
        }


        public JsonResult AddResposta(List<Prova> provas)
        {
            var pontos = 0;
            var totalPontosQuestionario = 0;
            var resultado ="";
            foreach (var prova in provas)
            {
                pontos += db.Perguntas.Find(prova.PerguntaId).Pontos;
                db.Provas.Add(prova);
            }
            db.SaveChanges();
            var pergunta = db.Perguntas.Find(provas[0].PerguntaId);
            var questionario = db.Questionarios.Find(pergunta.QuestionarioId);

            foreach(var questao in questionario.Perguntas)
            {
                totalPontosQuestionario += questao.Pontos;
            }

            if (pontos >= ((totalPontosQuestionario * 50) / 100))
                resultado = "Aprovado";
            if (pontos < ((totalPontosQuestionario * 50) / 100))
                resultado = "reprovado";

            var exame = db.Exames.Find(provas[0].ExameId);
            exame.Resultado = pontos;

            db.Entry(exame).State = EntityState.Modified;
            db.SaveChanges();

            return Json(new { pontos }, JsonRequestBehavior.AllowGet);
        }
    }
}