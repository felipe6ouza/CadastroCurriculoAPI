using AutoMapper;
using Curriculo.API.ViewModels;
using Curriculo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Curriculo.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PessoaViewModel, Pessoa>().ReverseMap();
            CreateMap<ExperienciaTrabalhoViewModel, ExperienciaTrabalho>().ReverseMap();
            CreateMap<ExperienciaViewModel, Experiencia>().ReverseMap();
            CreateMap<FormacaoViewModel, Formacao>().ReverseMap();
    
        }
    }
}
