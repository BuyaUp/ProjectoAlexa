using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Municipio : Entity<string>
    {
        public Municipio()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string MunicipioNome { get; set; }
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
