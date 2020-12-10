using Curriculo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Mappings
{
    public class ExperienciaMapping : IEntityTypeConfiguration<Experiencia>
    {
        public void Configure(EntityTypeBuilder<Experiencia> builder)
        {
            builder.ToTable("Experiencias");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Tecnologia).HasColumnType("VARCHAR(80)");
            builder.Property(e => e.DetalheExperiencia).HasColumnType("VARCHAR(500)");

        }
    }
}
