using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Curriculo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Repository
{
    public class ExperienciaTrabalhoRepository : Repository<ExperienciaTrabalho>, IExperienciaTrabalhoRepository
    {
        public ExperienciaTrabalhoRepository(MeuDbContext dbContext) : base(dbContext) { }
    
    }
}
