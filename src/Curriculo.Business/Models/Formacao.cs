using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Business.Models
{
    public class Formacao : Entity
    {
        public Guid PessoaId { get; set; }

        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime DataConclusao { get; set; }


        /*EF Relation */
        public Pessoa Pessoa { get; set; }

    }
}
