using AutoMapper;
using Curriculo.API.ViewModels;
using Curriculo.Business.Interfaces;
using Curriculo.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public CurriculoController(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaViewModel>>> ObterTodos()
        {
            var listaPessoas = _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.ObterTodos());

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
            pessoaViewModel.Id = pessoa.Id;
            return CreatedAtAction ("POST", pessoaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid Id, PessoaViewModel pessoaViewModel)
        {
            if (Id != pessoaViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var update = _mapper.Map<Pessoa>(pessoaViewModel);

            
            foreach(var formacao in update.Formacao)
            {
                formacao.PessoaId = pessoaViewModel.Id;
            }

            foreach (var experiencia in update.Experiencia)
            {
                experiencia.PessoaId = pessoaViewModel.Id;
            }

            foreach (var experienciaTrabalho in update.ExperienciaTrabalho)
            {
                experienciaTrabalho.PessoaId = pessoaViewModel.Id;
            }

            try
            {
                await _pessoaRepository.Atualizar(update);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Pessoa)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = await entry.GetDatabaseValuesAsync();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            // proposedValues[property] = <value to be saved>;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                    }
                    else
                    {
                        throw new NotSupportedException(
                            "Don't know how to handle concurrency conflicts for "
                            + entry.Metadata.Name);
                    }
                }
            }


                return NoContent();
        }


    }
}
