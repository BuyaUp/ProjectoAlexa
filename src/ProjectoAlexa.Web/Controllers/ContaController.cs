﻿using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ProjectoAlexa.Web.Models;

namespace ProjectoAlexa.Web.Controllers
{
    public class ContaController : Controller
    {
        private readonly ProjectoBaseDataContext _context = new ProjectoBaseDataContext();

        // GET: Conta
        public ActionResult Criar()
        {
            return View();
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
                var usuario = UsuarioModel.ValidarUsuario(model.NomeUsuario, model.Senha);

                if (usuario == null)
                {
                    //Warning("Dados inválidos!", true);
                    ModelState.AddModelError("", "Login inválido.");
                    return View(model);
                }
                else
                {
                    if (!usuario.Ativo)
                    {
                        //Warning("Usuário bloqueado!", true);
                        ModelState.AddModelError("", "Usuário bloqueado!");
                        return View(model);
                    }

                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        usuario.NomeUsuario, DateTime.Now, DateTime.Now.AddMinutes(30),
                        false, usuario.UsuarioPerfil.PerfilNome,
                        FormsAuthentication.FormsCookiePath);

                    var authCrypt = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, authCrypt);

                    HttpContext.Response.Cookies.Add(authCookie);

                   // Success("Bem-vindo!");
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(model);
            }
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