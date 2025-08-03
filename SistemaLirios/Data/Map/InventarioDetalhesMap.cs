using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class InventarioDetalhesMap : IEntityTypeConfiguration<InventarioDetalhesModel>
    {
        public void Configure(EntityTypeBuilder<InventarioDetalhesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdInventario).IsRequired();
            builder.Property(x => x.IdProduto).IsRequired();
            builder.Property(x => x.Previsao).IsRequired();
            builder.Property(x => x.Contabilizado).IsRequired();

            builder.HasOne(x => x.Inventario).WithMany().HasForeignKey(x => x.IdInventario);
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.IdProduto);
        }
    }
}
