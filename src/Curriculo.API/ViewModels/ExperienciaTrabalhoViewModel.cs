using System;
using System.ComponentModel.DataAnnotations;

namespace Curriculo.API.ViewModels
{
    public class ExperienciaTrabalhoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cargo { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DetalheExperiencia { get; set; }
    }
}