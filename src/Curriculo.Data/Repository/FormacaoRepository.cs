using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Curriculo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Repository
{
    public class FormacaoRepository : Repository<Formacao>, IFormacaoRepository
    {
        public FormacaoRepository(MeuDbContext db) : base(db) { }
     
    }
}
