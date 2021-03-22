using AutoMapper;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class ConcursoController : BaseController
    {
        // GET: Concurso
        public ActionResult Index()
        {
            var concurso = ConcursoRepositorio.BuscarTodos();
            return View(concurso);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

       

    }
}