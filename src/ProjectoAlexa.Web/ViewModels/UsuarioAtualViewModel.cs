using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class UsuarioAtualViewModel
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataNascimento { get; set; }

        public string UltimaCandidaturaId { get; set; }
        public int DataUltimaCandidatura { get; set; }

        public DateTime DataExame { get; set; }
        public DateTime DataResultados { get; set; }
        public bool EstadoCandidatura { get; set; }

    }
}
