using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class PerguntaViewModel
    {
        public int PerguntaId { get; set; }
        public string Descricao { get; set; }
        public int QuestionarioId { get; set; }
        public int Pontos { get; set; }
        public int TotalRespostas { get; set; }
        public ICollection<RespostaViewModel> Respostas { get; set; }
    }
}
