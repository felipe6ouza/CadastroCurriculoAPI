using Curriculo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Mappings
{
    public class ExperienciasTrabalhoMapping : IEntityTypeConfiguration<ExperienciaTrabalho>
    {
        public void Configure(EntityTypeBuilder<ExperienciaTrabalho> builder)
        {
            builder.ToTable("ExperienciasTrabalho");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Empresa).HasColumnType("VARCHAR(80)");
            builder.Property(e => e.Cargo).HasColumnType("VARCHAR(80)");
            builder.Property(e => e.DetalheExperiencia).HasColumnType("VARCHAR(1000)");

        }
    }
}
