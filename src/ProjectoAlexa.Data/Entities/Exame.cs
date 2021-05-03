using ProjectoAlexa.Data.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Data.Entities
{
    public class Exame : Entity<string>
    {
        public Exame()
        {
            Id = Guid.NewGuid().ToString();
            Resultado = false;
        }

        public string CandidaturaId { get; set; }
        public int QuestionarioId { get; set; }
        public int Pontos { get; set; }
        public bool Resultado { get; set; }
        public DateTime? TempoConclusao { get; set; }

        public EnumEstadoExame EstadoExame { get; set; }

        public virtual Candidatura Candidatura { get; set; }
        public virtual Questionario Questionario { get; set; }
        public virtual ICollection<Prova> Provas { get; set; }
    }
}
