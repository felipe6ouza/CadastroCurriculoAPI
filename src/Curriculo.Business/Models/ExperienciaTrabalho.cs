using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Business.Models
{
   public class ExperienciaTrabalho : Entity
    {
        public Guid PessoaId { get; set; }

        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }

        /*EF Relation */
        public Pessoa Pessoa { get; set; }
    }
}
