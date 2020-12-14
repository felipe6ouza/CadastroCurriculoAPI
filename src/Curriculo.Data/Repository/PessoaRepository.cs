using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Curriculo.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curriculo.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(MeuDbContext dbContext): base(dbContext){}

        public override async Task<List<Pessoa>> ObterTodos()
        {
            return await Db.Pessoa
                 .AsNoTracking()
                 .Include(f => f.Formacao)
                 .Include(f => f.Experiencia)
                 .Include(f => f.ExperienciaTrabalho)
                 .ToListAsync();
        }
        public async Task<IEnumerable<Experiencia>> ObterExperienciaPessoa(Guid id)
        {
            return (IEnumerable<Experiencia>)await Db.Pessoa
                .AsNoTracking()
                .Include(e => e.Experiencia)
                .FirstOrDefaultAsync(f => f.Id == id);

        }

        public async Task<IEnumerable<ExperienciaTrabalho>> ObterExperienciaTrabalhoPessoa(Guid id)
        {
            return (IEnumerable<ExperienciaTrabalho>)await Db.Pessoa
                .AsNoTracking()
                .Include(e => e.ExperienciaTrabalho)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Formacao>> ObterFormacaoPessoa(Guid id)
        {
            return (IEnumerable<Formacao>)await Db.Pessoa
                .AsNoTracking()
                .Include(f => f.Formacao)
                .FirstOrDefaultAsync(f => f.Id == id);
      
        }

        public async Task<Pessoa> ObterDadosCompletosPessoa(Guid id)
        {
            return await Db.Pessoa
                 .AsNoTracking()
                 .Include(f => f.Formacao)
                 .Include(f => f.Experiencia)
                 .Include(f => f.ExperienciaTrabalho)
                 .FirstAsync(f => f.Id == id);
                 
        }

    }
}
