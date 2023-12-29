using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class ServicoMap : IEntityTypeConfiguration<ServicoModel>
    {
        public void Configure(EntityTypeBuilder<ServicoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoServicoId).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);

            builder.HasOne(x => x.TipoServico).WithMany().HasForeignKey(x => x.TipoServicoId);
        }
    }
}
