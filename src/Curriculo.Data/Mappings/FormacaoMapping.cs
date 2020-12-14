using Curriculo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Curriculo.Data.Mappings
{
    public class FormacaoMapping : IEntityTypeConfiguration<Formacao>
    {
        public void Configure(EntityTypeBuilder<Formacao> builder)
        {
            builder.ToTable("Formacoes");
            builder.HasKey(p => p.Id);
            builder.Property(f => f.Curso).HasColumnType("VARCHAR(60)");
            builder.Property(f => f.Status).HasColumnType("VARCHAR(50)");
            builder.Property(f => f.DataConclusao).HasColumnType("Date").IsRequired(false);
        }
    }
}
