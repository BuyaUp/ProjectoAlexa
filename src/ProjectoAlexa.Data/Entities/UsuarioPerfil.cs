using ProjectoAlexa.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class UsuarioPerfil : Entity<int>
    {
        public string PerfilNome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }

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

        public int Salvar()
        {
            var ret = 0;

            using (var db = new ProjectoBaseDataContext())
            {
                var model = db.UsuarioPerfis
                    .Include(x => x.Usuarios)
                    .Where(x => x.PerfilNome == this.PerfilNome)
                    .FirstOrDefault();

                if (model == null)
                {
                    db.UsuarioPerfis.Add(this);
                }
                else
                {
                    model.PerfilNome = this.PerfilNome;
                    model.Ativo = this.Ativo;
                    db.UsuarioPerfis.Attach(this);
                    db.Entry(this).State = EntityState.Unchanged;
                }

                db.SaveChanges();
                ret = this.Id;
            }

            return ret;
        }
    }
}
