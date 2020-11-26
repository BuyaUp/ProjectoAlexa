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
    }
}
