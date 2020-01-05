using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CursoWebApi.Projeto2.Models
{
    public class Cidade
    {
        [Key]
        public int cod_cidade { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="Tamanho inválido", MinimumLength = 5)]
        [Column (TypeName = "varchar")]
        public string  nome_cidade { get; set; }

        [Required]
        [StringLength(2, ErrorMessage = "Tamanho inválido", MinimumLength =2)]
        [Column(TypeName = "char")]
        public string uf_cidade { get; set; }

        [StringLength(8, ErrorMessage = "Tamanho inválido", MinimumLength = 8)]
        [Column(TypeName = "varchar")]
        public string cep_cidade { get; set; }

        public IEnumerable<Usuario> usuarios { get; set; }

    }
}