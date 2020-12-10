using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Business.Models
{
    public class Experiencia : Entity
    {
        public Guid PessoaId { get; set; }
        public string Tecnologia { get; set; }
        public int AnosExperiencia { get; set; }
        public string DetalheExperiencia { get; set; }
       
        /*EF Relation */
        public Pessoa Pessoa { get; set; }

    }
}
