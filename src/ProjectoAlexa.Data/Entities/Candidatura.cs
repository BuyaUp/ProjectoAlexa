using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Candidatura : Entity<string>
    {
        public Candidatura()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string UsuarioId { get; set; }
        public int AreaCandidaturaId { get; set; }
        public string DocumentosId { get; set; }

        public virtual Documento Documento { get; set; }
        public virtual AreaCandidatura AreaCandidatura { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
