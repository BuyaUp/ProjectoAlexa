using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Questionario:Entity<int>
    {
        public string Titulo { get; set; }
        public string UsuarioId { get; set; }
        public int AreaCandidaturaId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual AreaCandidatura AreaCandidatura { get; set; }
        public virtual ICollection<Pergunta> Perguntas { get; set; }
    }
}
