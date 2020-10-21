using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Seeds
{
    public class UsuarioPerfilSeed
    {
        public static void Seed(ProjectoBaseDataContext context)
        {
            context.UsuarioPerfis.AddOrUpdate(x => x.PerfilNome,
                new UsuarioPerfil() { PerfilNome = "Administrador", Ativo = true }, 
                new UsuarioPerfil() { PerfilNome = "Gestor", Ativo = true }, 
                new UsuarioPerfil() { PerfilNome = "Usuário", Ativo = true });


            context.SaveChanges();
        }
    }
}
