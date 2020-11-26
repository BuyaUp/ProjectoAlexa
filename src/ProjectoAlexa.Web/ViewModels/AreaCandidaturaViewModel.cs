using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class AreaCandidaturaViewModel
    {
        #region Dados 
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} campo obrigatório!")]
        public string AreaNome { get; set; }
        #endregion
    }
}
