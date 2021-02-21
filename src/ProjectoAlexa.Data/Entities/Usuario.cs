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

        public string Genero { get; set; }

        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Candidatura> Candidaturas { get; set; }
        public virtual ICollection<Questionario> Questionarios { get; set; }
        public virtual UsuarioPerfil UsuarioPerfil { get; set; }

        #endregion
    }
}
