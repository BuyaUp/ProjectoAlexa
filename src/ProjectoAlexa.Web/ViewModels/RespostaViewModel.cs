using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class RespostaViewModel
    {
        public string Descricao { get; set; }
        public bool RespostaCerta { get; set; }
        public int PerguntaId { get; set; }

    }
}
