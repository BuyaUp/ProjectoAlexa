using ProjectoAlexa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.DataContexts
{
    internal class DbInitializer : CreateDatabaseIfNotExists<ProjectoBaseDataContext>
    {
        protected override void Seed(ProjectoBaseDataContext context)
        {
            //Cadastro de perfis de usuários
            var perfilAdmin = new UsuarioPerfil() { PerfilNome = "Administrador" };
            var perfilGestor = new UsuarioPerfil() { PerfilNome = "Gestor" };
            var perfilCliente = new UsuarioPerfil() { PerfilNome = "Usuário" };

            var perfis = new List<UsuarioPerfil> {
                perfilAdmin,
                perfilGestor,
                perfilCliente
            };
            context.UsuarioPerfis.AddRange(perfis);

            //Cadastro de usuários
            var userMaster = new Usuario() { NomeUsuario = "Admin", Email = "admin@projectobase.com", Senha = "master", UsuarioPerfil = perfilAdmin };

            var usuarios = new List<Usuario>() {
                userMaster,
            };
            context.Usuarios.AddRange(usuarios);

            context.SaveChanges();
        }
    }
}
