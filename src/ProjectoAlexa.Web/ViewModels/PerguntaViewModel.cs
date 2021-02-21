using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class PerguntaViewModel
    {
        public string Descricao { get; set; }
        public int QuestionarioId { get; set; }
        public ICollection<RespostaViewModel> Respostas { get; set; }
    }
}
