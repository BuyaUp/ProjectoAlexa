using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Documento : Entity<string>
    {
        public Documento()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string BI { get; set; }
        public bool? BIConfirma { get; set; }
        public string CertificadoHabilitacoes { get; set; }
        public bool? CertificadoHabilitacoesConfirma { get; set; }
        public string CartaParaMinistro { get; set; }
        public bool? CartaParaMinistroConfirma { get; set; }

        public virtual ICollection<Candidatura> Candidaturas { get; set; }
    }
}
