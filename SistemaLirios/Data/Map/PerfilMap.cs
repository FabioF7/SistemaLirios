using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class PerfilMap : IEntityTypeConfiguration<PerfilModel>
    {
        public void Configure(EntityTypeBuilder<PerfilModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomePerfil).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DescricaoPerfil).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.DtAlteracao);

        }
    }
}
