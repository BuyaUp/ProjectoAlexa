using ProjectoAlexa.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class UsuarioController : BaseController
    {
        public ActionResult Perfil()
        {
            return View();
        }
    }
}