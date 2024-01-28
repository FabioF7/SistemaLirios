using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class PagamentoMap : IEntityTypeConfiguration<PagamentoModel>
    {
        public void Configure(EntityTypeBuilder<PagamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.ValorPago).IsRequired();
            builder.Property(x => x.TipoTransacao).IsRequired();
            builder.Property(x => x.MetodoPagamento).IsRequired();
            builder.Property(x => x.DtPagamento).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId);
        }
    }
}
