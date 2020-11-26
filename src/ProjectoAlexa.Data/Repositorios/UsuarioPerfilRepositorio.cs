using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Repositorios
{
    public class UsuarioPerfilRepositorio
    {
        public static UsuarioPerfil BuscarPeloNome(string perfilNome)
        {
            UsuarioPerfil ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.UsuarioPerfis
                    .Where(x => x.PerfilNome == perfilNome)
                    .FirstOrDefault();
            }

            return ret;
        }

        public int Salvar(UsuarioPerfil perfil)
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = db.UsuarioPerfis
                    .Where(x => x.PerfilNome == perfil.PerfilNome)
                    .FirstOrDefault();

                if (model == null)
                {
                    db.UsuarioPerfis.Add(perfil);
                }
                else
                {
                    model.PerfilNome = perfil.PerfilNome;
                    model.Ativo = perfil.Ativo;
                    db.UsuarioPerfis.Attach(perfil);
                    db.Entry(perfil).State = EntityState.Unchanged;
                }

                db.SaveChanges();
                ret = perfil.Id;
            }

            return ret;
        }

    }
}
