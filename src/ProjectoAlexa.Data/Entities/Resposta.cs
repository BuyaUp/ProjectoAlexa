using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Resposta : Entity<int>
    {
        public string Descricao { get; set; }
        public bool RespostaCerta { get; set; }
        public int  PerguntaId { get; set; }
        public virtual Pergunta Pergunta { get; set; }
    }
}
