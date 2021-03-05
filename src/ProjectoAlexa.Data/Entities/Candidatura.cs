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
        public string BI { get; set; }
        public string Certificado { get; set; }
        public string Carta { get; set; }

        public string ProvinciaId { get; set; }

        public virtual AreaCandidatura AreaCandidatura { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Exame> Exames { get; set; }
    }
}
