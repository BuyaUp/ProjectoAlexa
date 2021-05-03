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
            var exames = db.Exames.ToList();
            return View(exames);
        }

        public ActionResult FazerExame(string IdCandidatura)
        {
            var candidatura = CandidaturaRepositorio.BuscarPeloId(IdCandidatura);
            var questionario = QuestionarioRepositorio.BuscarTodos().Where(q => q.AreaCandidaturaId == candidatura.AreaCandidaturaId).FirstOrDefault();

            Exame exame;
            exame = new Exame
            {
                Ativo = true,
                CandidaturaId = candidatura.Id,
                QuestionarioId = questionario.Id,
                Pontos = 0,
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


        public JsonResult AddResposta(List<Prova> provas, int totalPontos)
        {
            var pontos = 0;
            var perguntaId = 0;
            var resultado = false;

            //Calcular pontos por cada resposta certa
            foreach (var prova in provas)
            {
                var resposta = db.Respostas.Find(prova.RespostaSelecionadaId);

                if (resposta.RespostaCerta == true)
                {
                    pontos += db.Perguntas.Find(resposta.PerguntaId).Pontos;
                }
                perguntaId = prova.PerguntaId;
                db.Provas.Add(prova);
            }


            //Se acertar mais de 50% do total de pontos = aprovado, caso contrário = reprovado.
            if (pontos >= ((totalPontos * 50) / 100))
            {
                resultado = true;
            }

            if (pontos < ((totalPontos * 50) / 100))
            {
                resultado = false;
            }


            var porcentagem = (pontos * 100) / totalPontos;


            var exame = db.Exames.Find(provas[0].ExameId);
            exame.Resultado = resultado;
            exame.Pontos = pontos;

            db.Entry(exame).State = EntityState.Modified;
            db.SaveChanges();


            return Json(new { pontos, porcentagem,resultado}, JsonRequestBehavior.AllowGet);
        }
    }
}