using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Criar()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}