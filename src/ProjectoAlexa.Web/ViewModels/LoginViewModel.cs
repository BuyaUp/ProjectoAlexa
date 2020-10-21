﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
