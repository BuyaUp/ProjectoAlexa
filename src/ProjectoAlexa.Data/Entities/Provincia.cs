using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Provincia : Entity<string>
    {
        public Provincia()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string ProvinciaNome { get; set; }

        public ICollection<Candidatura> Candidaturas { get; set; }
    }
}
