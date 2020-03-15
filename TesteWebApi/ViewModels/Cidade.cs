using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteWebApi.ViewModels
{
    public class Cidade
    {
        [Key]
        public int cod_cidade { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        public string nome_cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Tamanho inválido", MinimumLength = 2)]
        public string uf_cidade { get; set; }

        [StringLength(8, ErrorMessage = "Tamanho inválido", MinimumLength = 8)]
        public string cep_cidade { get; set; }

        public IEnumerable<Usuario> usuarios { get; set; }
    }
}