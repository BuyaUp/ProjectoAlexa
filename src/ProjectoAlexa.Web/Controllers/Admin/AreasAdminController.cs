using AutoMapper;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.ViewModels;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers.Admin
{
    public class AreasAdminController : BaseController
    {
        // GET: AreasAdmin
        public ActionResult Index()
        {
            var areas = AreaCandidaturaRepositorio.BuscarTodas();
            return View(areas);
        }

        public ActionResult Create(int ?id)
        {
            var area = Mapper.Map<AreaCandidaturaViewModel>(AreaCandidaturaRepositorio.BuscarPeloId(id));

            return View(area);
        }

        [HttpPost]
        public ActionResult Create(AreaCandidaturaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            else
            {

                var id = AreaCandidaturaRepositorio.Salvar(Mapper.Map<AreaCandidatura>(viewModel));

                if (id == 0)
                    return View(viewModel);

                return RedirectToAction("Index", "AreasAdmin");
            }
        }



        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}