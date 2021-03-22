using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectoAlexa.Web.ViewModels
{
    public class ConcursoViewModel
    {

        [Required(ErrorMessage = "O campo é Obrigatorio!!")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo é Obrigatorio!!")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo é Obrigatorio!!")]
        [DataType(DataType.Date)]
        public DateTime DataExames { get; set; }

        [Required(ErrorMessage = "O campo é Obrigatorio!!")]
        [DataType(DataType.Date)]
        public DateTime DataResultados { get; set; }
  
    }
}
