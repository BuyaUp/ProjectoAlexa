using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class ExameViewModel
    {
        public string ExameId { get; set; }
        public string CandidaturaId { get; set; }
        public int QuestionárioId { get; set; }
        public int Resultado { get; set; }
        public DateTime TempoConclusao { get; set; }
        public int PerguntaId { get; set; }
        public int RespostaSelecionadaId { get; set; }
    }
}
