using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Pergunta : Entity<int>
    {
        public string Descricao { get; set; }
        public int Pontos { get; set; }
        public int QuestionarioId { get; set; }
        public virtual Questionario Questionario { get; set; }

        public virtual ICollection<Resposta> Respostas { get; set; }

        public int TotalRespostas()
        {
            if (Respostas == null)
                return 0;

            return Respostas.Count();
        }
    }
}
