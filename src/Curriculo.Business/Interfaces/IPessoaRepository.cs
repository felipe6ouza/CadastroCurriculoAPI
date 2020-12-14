using Curriculo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curriculo.Business.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        Task<Pessoa> ObterDadosCompletosPessoa(Guid id);
        Task<IEnumerable<ExperienciaTrabalho>> ObterExperienciaTrabalhoPessoa(Guid id);
        Task<IEnumerable<Formacao>> ObterFormacaoPessoa(Guid id);
        Task<IEnumerable<Experiencia>> ObterExperienciaPessoa(Guid id);
    }
}
