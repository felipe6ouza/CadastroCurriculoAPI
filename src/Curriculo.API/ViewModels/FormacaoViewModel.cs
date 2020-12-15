using System;
using System.ComponentModel.DataAnnotations;

namespace Curriculo.API.ViewModels
{
    public class FormacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Curso { get; set; }

        [Required(ErrorMessage = "O campo é {0} obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Status { get; set; }

        private DateTime? _dataConclusao;
        public DateTime? DataConclusao
        {
            get => _dataConclusao;

            set
            {
                if(Status == "Trancado")
                {
                    _dataConclusao = null;
                }
                _dataConclusao = value;
            }
        }


    }
}