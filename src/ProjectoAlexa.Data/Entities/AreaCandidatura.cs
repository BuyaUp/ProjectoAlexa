using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class AreaCandidatura : Entity<int>
    {
        public string AreaNome { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
        public virtual ICollection<Candidatura> Candidaturas  { get; set; }
        public virtual ICollection<Questionario> Questionarios { get; set; }
    }
}
