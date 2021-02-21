using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class QuestionarioViewModel
    {
        public string Titulo { get; set; }
        public string UsuarioId { get; set; }
        public int AreaCandidaturaId { get; set; }
        public  ICollection<PerguntaViewModel> Perguntas { get; set; }
    }
}
