using AutoMapper;
using Curriculo.API.ViewModels;
using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curriculo.API.Controllers
{
    [Route("api/curriculo")]
    public class CurriculoController : MainController
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CurriculoController(IPessoaRepository pessoaRepository, IMapper mapper, ILogger<CurriculoController> logger)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            _logger = logger;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> ObterTodos()
        {
            var listaPessoas = _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodos());
           
            //Testar Logging Manual para o Elmah.io
                // _logger.LogWarning("Capture The Warning Log");
                // _logger.LogCritical("Capture The Critical Log");


            return Ok(listaPessoas);
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaViewModel>> ObterPorId (Guid id)
        {
            var pessoa = _mapper.Map<PessoaViewModel>(await _pessoaRepository.ObterDadosCompletosPessoa(id));

            if (pessoa == null) return NotFound();

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaViewModel>> Post(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
            await _pessoaRepository.Adicionar(pessoa);
            var response = _mapper.Map <PessoaViewModel> (await _pessoaRepository.ObterDadosCompletosPessoa(pessoa.Id));

            return CreatedAtAction ("POST", response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid Id, PessoaViewModel pessoaViewModel)
        {
            if (Id != pessoaViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var update = _mapper.Map<Pessoa>(pessoaViewModel);

            await _pessoaRepository.Atualizar(update);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var pessoa = await _pessoaRepository.ObterPorId(id);

            if (pessoa == null)
                return NotFound();

            await _pessoaRepository.Remover(id);
            
            return Ok();
        }
    }
}
