using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class InventarioMap : IEntityTypeConfiguration<InventarioModel>
    {
        public void Configure(EntityTypeBuilder<InventarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Situacao);
            builder.Property(x => x.Inicio).IsRequired();
            builder.Property(x => x.Concluido);
            builder.Property(x => x.Contado_por);
            builder.Property(x => x.Revisado_por);
            builder.Property(x => x.Obsevacoes);
            builder.Property(x => x.Contabilizado_Total);
        }
    }
}
