using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class PrestadorMap : IEntityTypeConfiguration<PrestadorModel>
    {
        public void Configure(EntityTypeBuilder<PrestadorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IdTipo).IsRequired();
            builder.Property(x => x.Local).IsRequired().HasMaxLength(455);
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);

        }
    }
}
