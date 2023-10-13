using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<VendaModel>
    {
        public void Configure(EntityTypeBuilder<VendaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ValorVenda).IsRequired();
            builder.Property(x => x.DtVenda).IsRequired();
            builder.Property(x => x.IdCliente).IsRequired();
            builder.Property(x => x.IdProduto).IsRequired();
            builder.Property(x => x.CustoProduto).IsRequired();
            builder.Property(x => x.MetodoPagamento).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.TipoTransacao).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.PreVenda).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);
        }
    }
}
