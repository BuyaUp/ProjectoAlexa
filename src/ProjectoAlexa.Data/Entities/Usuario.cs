using ProjectoAlexa.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectoAlexa.Data.Helpers;

namespace ProjectoAlexa.Data.Entities
{
    public class Usuario : Entity<string>
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
        }

        #region Atributos

        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioPerfilId { get; set; }

        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Candidatura> Candidaturas { get; set; }

        #endregion

        public virtual UsuarioPerfil UsuarioPerfil { get; set; }

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


        public static Usuario BuscarPeloId(string id)
        {
            Usuario ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Usuarios.Find(id);
            }

            return ret;
        }

        public static bool ExcluirPeloId(string id)
        {
            var ret = false;

            if (id != null)
            {
                using (var db = new ProjectoBaseDataContext())
                {
                    var usuario = BuscarPeloId(id);
                    db.Usuarios.Remove(usuario);
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
