using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using AutoMapper;
using ProjectoAlexa.Data.Entities;

namespace ProjectoAlexa.Web.Controllers
{
    public class ContaController : BaseController
    {
        // GET: Conta
        public ActionResult Registar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registar(RegistarViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            else
            {
                viewModel.UsuarioPerfilId = UsuarioPerfil.BuscarPeloNome("Usuário").Id;
                var vm = Mapper.Map<Usuario>(viewModel);
                var id = vm.Salvar();

                if (string.IsNullOrEmpty(id))
                    return View(viewModel);

                return RedirectToAction("Login", "Conta");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = Usuario.ValidarUsuario(model.NomeUsuario, model.Senha);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Login inválido.");
                    return View(model);
                }
                else
                {
                    if (!usuario.Ativo)
                    {
                        ModelState.AddModelError("", "Usuário bloqueado!");
                        return View(model);
                    }

                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        usuario.NomeUsuario, DateTime.Now, DateTime.Now.AddMinutes(30),
                        model.LembrarMe, usuario.UsuarioPerfil.PerfilNome,
                        FormsAuthentication.FormsCookiePath);

                    var authCrypt = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, authCrypt);

                    HttpContext.Response.Cookies.Add(authCookie);

                    // Success("Bem-vindo!");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Conta");
        }

    }
}