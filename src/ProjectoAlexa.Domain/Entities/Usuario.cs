using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Domain.Entities
{
    public class Usuario : EntityBase<string>
    {
        public Usuario()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int UsuarioPerfilId { get; set; }
        public int MunicipioId { get; set; }

        public virtual UsuarioPerfil UsuarioPerfil { get; set; }
    }
}
