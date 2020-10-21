﻿using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Seeds
{
    public class UsuarioSeed
    {
        public static void Seed(ProjectoBaseDataContext context)
        {
            if (!context.UsuarioPerfis.Where(u => u.PerfilNome == "Administrador").Any())
            {
                context.UsuarioPerfis.AddOrUpdate(x => x.PerfilNome,
                new UsuarioPerfil() { PerfilNome = "Administrador", Ativo = true });

            }
            var perfilAdmin = context.UsuarioPerfis.Where(u => u.PerfilNome == "Administrador").FirstOrDefault();

            context.Usuarios.AddOrUpdate(x => x.Email,
                new Usuario()
                {
                    NomeUsuario = "Admin",
                    Email = "admin@projectoalexa.com",
                    Senha = "master",
                    NomeCompleto = "Administrador do Sistema",
                    DataNascimento = DateTime.Now.AddYears(-25),
                    UsuarioPerfilId = perfilAdmin.Id
                    //UsuarioPerfil = perfilAdmin
                }
                );
        }
    }
}
