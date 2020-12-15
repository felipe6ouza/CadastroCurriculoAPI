using System;
using System.ComponentModel.DataAnnotations;

namespace Curriculo.API.ViewModels
{
    public class ExperienciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Tecnologia { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        public int AnosExperiencia { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DetalheExperiencia { get; set; }


    }
}