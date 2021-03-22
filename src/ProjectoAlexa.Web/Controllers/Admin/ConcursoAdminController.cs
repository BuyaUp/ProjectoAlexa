using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.ViewModels;
using System.Web.Mvc;

namespace ProjectoAlexa.Web.Controllers.Admin
{
    public class ConcursoAdminController : BaseController
    {

        public ActionResult Index()
        {
            var concurso = ConcursoRepositorio.RecuperarLista();
            return View(concurso);
        }



        public ActionResult Create(string id)
        {
            var area = Mapper.Map<ConcursoViewModel>(ConcursoRepositorio.BuscarPeloId(id));

            return View(area);
        }



        [HttpPost]
        public ActionResult Create(ConcursoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            else
            {


                var id = ConcursoRepositorio.Salvar(Mapper.Map<Concurso>(viewModel));

                if (id == null)
                    return View(viewModel);

                return RedirectToAction("Index", "ConcursoAdmin");
            }
        }
    }
}