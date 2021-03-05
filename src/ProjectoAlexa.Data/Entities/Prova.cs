using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Prova : Entity<string>
    {
        public Prova()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string ExameId { get; set; }
        public int PerguntaId { get; set; }
        public int RespostaSelecionadaId { get; set; }

        public virtual Exame Exame { get; set; }
        public virtual Pergunta Pergunta { get; set; }
        public virtual Resposta Resposta { get; set; }
    }
}
