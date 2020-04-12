using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteWebApi.ViewModels
{
    public class Login
    {
        [Required]
        [StringLength(20, ErrorMessage = "Tamanho inválido", MinimumLength = 3)]
        public string usuario { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Tamanho inválido", MinimumLength = 2)]
        public string senha { get; set; }
    }
}