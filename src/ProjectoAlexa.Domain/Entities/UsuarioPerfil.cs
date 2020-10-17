using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Domain.Entities
{
    public class UsuarioPerfil : EntityBase<int>
    {
        public string PerfilNome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
