using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class CandidaturaController : BaseController
    {
        private readonly CandidaturaRepositorio _candidaturaRep;

        public CandidaturaController()
        {
            _candidaturaRep = new CandidaturaRepositorio();
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddAtualizar()
        {

            return View();
        }



        [HttpPost]
        public ActionResult AddAtualizar(CandidaturaViewModel candidaturaView)
        {

            return View();

        }
    }
}