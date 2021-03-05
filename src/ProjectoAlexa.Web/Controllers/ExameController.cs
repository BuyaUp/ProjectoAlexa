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

        public ActionResult FazerExame()
        {
            return View();
        }
    }
}