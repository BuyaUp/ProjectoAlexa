using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class CandidaturaViewModel
    {
        public string UsuarioId { get; set; }

        [Required(ErrorMessage = "Selecione o Area de candidatura.")]
        public int AreaCandidaturaId { get; set; }
        public string DocumentosId { get; set; }
    }
}
