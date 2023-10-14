using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class TipoServicoMap : IEntityTypeConfiguration<TipoServicoModel>
    {
        public void Configure(EntityTypeBuilder<TipoServicoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeTipoServico).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);

        }
    }
}
