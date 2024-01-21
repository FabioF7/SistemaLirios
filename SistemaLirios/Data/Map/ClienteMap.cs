using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Celular).IsRequired();
            builder.Property(x => x.CEP).IsRequired().HasMaxLength(8);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.DtNascimento).IsRequired();
            builder.Property(x => x.Sexo).IsRequired();
            builder.Property(x => x.Indicacao);
            builder.Property(x => x.Bloqueado).IsRequired();
            builder.Property(x => x.Inadimplencia).IsRequired();
            builder.Property(x => x.LimiteInadimplencia);
            builder.Property(x => x.Observacoes);
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);

        }
    }
}
