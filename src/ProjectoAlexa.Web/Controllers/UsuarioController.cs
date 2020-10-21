using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Perfil()
        {
            return View();
        }
    }
}