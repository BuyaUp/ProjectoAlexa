using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class RegistarViewModel
    {
        #region Dados de Acesso
        [Required(ErrorMessage = "{0} Campo obrigatório!")]
        [EmailAddress]
        //[MaxLength(254, ErrorMessage = "O {0} deve ter no máximo {2} caracteres")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação devem ser iguais.")]
        public string ConfirmarSenha { get; set; }
        #endregion


        #region Dados Pessoais e Documentos

        [Required(ErrorMessage = "{0} Campo obrigatório!")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "{0} Campo obrigatório!")]
        public string Genero { get; set; } 
        #endregion


    }
}
