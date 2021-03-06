﻿using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Repositorios;

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
                if(DateTime.Now.Year - viewModel.DataNascimento.Year < 18)
                {
                    ViewBag.mensagem = "Deve ser maior de 18 anos para efetuar o cadastro!";
                    return View(viewModel);
                }
                viewModel.UsuarioPerfilId = UsuarioPerfilRepositorio.BuscarPeloNome("Usuário").Id;
                viewModel.NomeUsuario = viewModel.Email;

                var id = UsuarioRepositorio.Salvar(Mapper.Map<Usuario>(viewModel));

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
                var usuario = UsuarioRepositorio.ValidarUsuario(model.Email, model.Senha);

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
                        usuario.Email, DateTime.Now, DateTime.Now.AddMinutes(30),
                        model.LembrarMe, usuario.UsuarioPerfil.PerfilNome,
                        FormsAuthentication.FormsCookiePath);

                    var authCrypt = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, authCrypt);

                    HttpContext.Response.Cookies.Add(authCookie);

                    if (usuario.UsuarioPerfil.PerfilNome.Contains("Administrador"))
                        return RedirectToAction("VisaoGeral", "Admin");
                    else if (usuario.UsuarioPerfil.PerfilNome.Contains("Usuário"))
                        return RedirectToAction("Perfil", "Usuario");


                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login", "Conta");
        }

    }
}