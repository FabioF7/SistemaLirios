using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Usuario).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordSalt).IsRequired();
            builder.Property(x => x.Ativo).IsRequired();
            builder.Property(x => x.IdPerfil).IsRequired();
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.DtAlteracao);

            builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.IdPerfil);

        }
    }
}
