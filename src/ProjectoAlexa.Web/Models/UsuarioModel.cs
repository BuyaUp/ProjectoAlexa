using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectoAlexa.Domain.Entities;

namespace ProjectoAlexa.Web.Models
{
    public class UsuarioModel : Usuario
    {
        #region Atributos

        public string Login { get; set; }
        public string Nome { get; set; }
        public virtual List<UsuarioPerfilModel> Perfis { get; set; }

        #endregion

        public static Usuario ValidarUsuario(string nomeUsuario, string senha)
        {
            Usuario ret = null;
            senha = CriptoHelper.Encrypt(senha);

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Usuarios
                    .Include(x => x.UsuarioPerfil)
                    .Where(x => x.NomeUsuario == nomeUsuario && x.Senha == senha)
                    .FirstOrDefault();
            }

            return ret;
        }

        public static UsuarioModel BuscarPeloId(string id)
        {
            UsuarioModel ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = (UsuarioModel)db.Usuarios.Find(id);
            }

            return ret;
        }

        public static bool ExcluirPeloId(string id)
        {
            var ret = false;

            if (BuscarPeloId(id) != null)
            {
                using (var db = new ProjectoBaseDataContext())
                {
                    var usuario = new Usuario { Id = id };
                    db.Usuarios.Attach(usuario);
                    db.Entry(usuario).State = EntityState.Deleted;
                    db.SaveChanges();
                    ret = true;
                }
            }

            return ret;
        }

        public string Salvar()
        {
            var ret = string.Empty;

            var model = BuscarPeloId(this.Id);

            using (var db = new ProjectoBaseDataContext())
            {
                if (model == null)
                {
                    if (!string.IsNullOrEmpty(this.Senha))
                    {
                        this.Senha = CriptoHelper.Encrypt(this.Senha);
                    }
                    db.Usuarios.Add(this);
                }
                else
                {
                    db.Usuarios.Attach(this);
                    db.Entry(this).State = EntityState.Modified;

                    if (string.IsNullOrEmpty(this.Senha))
                    {
                        db.Entry(this).Property(x => x.Senha).IsModified = false;
                    }
                    else
                    {
                        this.Senha = CriptoHelper.Encrypt(this.Senha);
                    }
                }

                db.SaveChanges();
                ret = this.Id;
            }

            return ret;
        }

        public bool AlterarSenha(string novaSenha)
        {
            var ret = false;

            using (var db = new ProjectoBaseDataContext())
            {
                this.Senha = CriptoHelper.Encrypt(novaSenha);
                db.Usuarios.Attach(this);
                db.Entry(this).Property(x => x.Senha).IsModified = true;
                db.SaveChanges();
            }

            return ret;
        }
    }
}
