using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Business.Models
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Formacao> Formacao { get; set; }
        public int AnosExperienciaTotal { get; set; }
        public List<Experiencia> Experiencia { get; set; }
        public List<ExperienciaTrabalho> ExperienciaTrabalho { get; set; }
    }
}
