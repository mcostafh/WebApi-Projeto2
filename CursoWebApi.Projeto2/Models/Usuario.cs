using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Models
{
    public class Usuario
    {
        [Key]
        public int Cod_cliente { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string nome { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string SobreNome { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string Cpf { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string TelResidencial { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Tamanho inválido", MinimumLength = 5)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        public Cidade cidade { get; set; }
        public int cod_cidade { get; set; }

    }
}