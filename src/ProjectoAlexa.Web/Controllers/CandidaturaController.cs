using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;
using ProjectoAlexa.Web.Helpers;
using ProjectoAlexa.Web.ViewModels;
using System;
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
            var candidaturas = CandidaturaRepositorio.RecuperarLista();
            return View(candidaturas);
        }

        public ActionResult Adicionar()
        {
            ViewBag.Areas = AreaCandidaturaRepositorio.BuscarTodas();
            ViewBag.Provincias = ProvinciaRepositorio.BuscarTodas();
            //var concursoAtual = ConcursoRepositorio.BuscarTodos();
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(CandidaturaViewModel candidaturaViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Areas = AreaCandidaturaRepositorio.BuscarTodas();
                return View(candidaturaViewModel);
            }
            else
            {
                if (candidaturaViewModel.BIFile != null)
                    candidaturaViewModel.BI = GuardarFicheiro(candidaturaViewModel.BIFile, User.Identity.Name);

                if (candidaturaViewModel.CertificadoFile != null)
                    candidaturaViewModel.Certificado = GuardarFicheiro(candidaturaViewModel.CertificadoFile, User.Identity.Name);

                if (candidaturaViewModel.CartaFile != null)
                    candidaturaViewModel.Carta = GuardarFicheiro(candidaturaViewModel.CartaFile, User.Identity.Name);

                candidaturaViewModel.UsuarioId = UsuarioRepositorio.BuscarPeloEmail(User.Identity.Name).Id;

                CandidaturaRepositorio.Salvar(Mapper.Map<Candidatura>(candidaturaViewModel));

                TempData["MsgAviso"] = "Candidatura enviada com sucesso!";

                return RedirectToAction("Perfil", "Usuario");
            }

        }

        #region Helper
        private string GuardarFicheiro(HttpPostedFileBase httpPostedFile, string usuarioId)
        {
            var folder = "Media/" + usuarioId + "/Documentos";
            string picSaved = string.Empty;

            // Criar o Nome/Identificador para a imagem/documento usando Guid e Nome
            var fileName = string.Format("{0}_{1}", Guid.NewGuid().ToString(), httpPostedFile.FileName);
            var response = FilesHelper.UploadPhoto(httpPostedFile, folder, fileName);
            if (response)
                //guardar a imagem na pasta do sistema
                picSaved = string.Format("~/{0}/{1}", folder, fileName);

            return picSaved;
        }
        #endregion
    }
}