using Curriculo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(P => P.DataNascimento).HasColumnType("Date");

            // 1 : n => Pessoa : Experiencia
            builder.HasMany(e => e.Experiencia)
               .WithOne(p => p.Pessoa)
               .HasForeignKey(e => e.PessoaId);

            // 1 : n => Pessoa : Formacao
            builder.HasMany(f => f.Formacao)
               .WithOne(p => p.Pessoa)
               .HasForeignKey(f => f.PessoaId);

            // 1 : n => Pessoa : Formacao
            builder.HasMany(e => e.ExperienciaTrabalho)
               .WithOne(p => p.Pessoa)
               .HasForeignKey(e => e.PessoaId);
        }
    }
}
