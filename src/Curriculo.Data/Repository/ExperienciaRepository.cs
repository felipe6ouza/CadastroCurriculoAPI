using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Curriculo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Repository
{
    public class ExperienciaRepository : Repository<Experiencia>, IExperienciaRepository
    {
        public ExperienciaRepository(MeuDbContext db) : base(db) { }
     
    }
}
