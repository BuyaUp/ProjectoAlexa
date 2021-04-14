using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Data.Repositorios.Questionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class ExameController : Controller
    {

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
                Ativo  =true,
                CandidaturaId = candidatura.Id,
                QuestionarioId = questionario.Id,                       
            };



            if (questionario == null)
            {
                ViewBag.Mensagem = "Erro ao realizar exame, verifique o estado da sua candidatura!";

                return View();
            }

            return View(questionario);
           
        }
    }
}