using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Curriculo.API.ViewModels
{
    public class PessoaViewModel
    { 
            [Key]
            public Guid Id { get; set; }

            [Required(ErrorMessage = "O campo é {0} obrigatório")]
            [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
            public string Nome { get; set; }

            [Required(ErrorMessage = "O campo é {0} obrigatório")]
            public DateTime DataNascimento { get; set; }
            public List<FormacaoViewModel> Formacao { get; set; }
        
            [Required(ErrorMessage = "O campo é {0} obrigatório")]
            public int AnosExperienciaTotal { get; set; }
            public List<ExperienciaViewModel> Experiencia { get; set; }
            public List<ExperienciaTrabalhoViewModel> ExperienciaTrabalho { get; set; }
    }
}
