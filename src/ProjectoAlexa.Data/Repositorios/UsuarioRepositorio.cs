using ProjectoAlexa.Data.DataContexts;
using ProjectoAlexa.Data.Entities;
using ProjectoAlexa.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectoAlexa.Data.Repositorios
{
    public class UsuarioRepositorio
    {
        public static Usuario ValidarUsuario(string email, string senha)
        {
            Usuario ret = null;

            senha = senha.Encrypt();
            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Usuarios
                    .Include(x => x.UsuarioPerfil)
                    .Where(x => x.Email == email && x.Senha == senha)
                    .FirstOrDefault();
            }

            return ret;
        }

        public static string Salvar(Usuario usuario)
        {
            var ret = string.Empty;

            var model = BuscarPeloId(usuario.Id);

            using (var db = new ProjectoBaseDataContext())
            {
                if (model == null)
                {
                    if (!string.IsNullOrEmpty(usuario.Senha))
                    {
                        usuario.Senha = usuario.Senha.Encrypt();
                    }
                    usuario.NomeUsuario = usuario.NomeCompleto.Split(' ')[0];// Buscar o primeiro nome
                    db.Usuarios.Add(usuario);
                }
                else
                {
                    db.Usuarios.Attach(usuario);
                    db.Entry(usuario).State = EntityState.Modified;

                    if (string.IsNullOrEmpty(usuario.Senha))
                    {
                        db.Entry(usuario).Property(x => x.Senha).IsModified = false;
                    }
                    else
                    {
                        usuario.Senha = usuario.Senha.Encrypt();
                    }
                }

                db.SaveChanges();
                ret = usuario.Id;
            }

            return ret;
            //return true;
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


        public static Usuario BuscarPeloEmail(string email)
        {
            Usuario ret = null;

            using (var db = new ProjectoBaseDataContext())
            {
                ret = db.Usuarios.Where(u => u.Email == email).FirstOrDefault();
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

        public bool AlterarSenha(string novaSenha)
        {
            var ret = false;

            using (var db = new ProjectoBaseDataContext())
            {
                //this.Senha = CriptoHelper.Encrypt(novaSenha);
                //db.Usuarios.Attach(this);
                //db.Entry(this).Property(x => x.Senha).IsModified = true;
                db.SaveChanges();
            }

            return ret;
        }

    }
}
