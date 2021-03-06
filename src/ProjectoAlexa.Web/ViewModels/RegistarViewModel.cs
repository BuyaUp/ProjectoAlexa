﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectoAlexa.Web.ViewModels
{
    public class RegistarViewModel
    {
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório!")]
        [EmailAddress]
        //[MaxLength(254, ErrorMessage = "O {0} deve ter no máximo {2} caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório!")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação devem ser iguais.")]
        public string ConfirmarSenha { get; set; }

        public int UsuarioPerfilId { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório!")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório!")]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "{0} campo obrigatório!")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

    }
}
