﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaLirios.Models;

namespace SistemaLirios.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(455);
            builder.Property(x => x.OrigemId).IsRequired();
            builder.Property(x => x.Codigo).HasMaxLength(15);
            builder.Property(x => x.CodigoDeBarra);
            builder.Property(x => x.ValorCusto).IsRequired();
            builder.Property(x => x.ValorVendaRevista);
            builder.Property(x => x.IdCategoria);
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.CadastradoPor).IsRequired().HasMaxLength(55);
            builder.Property(x => x.DtCadastro).IsRequired();
            builder.Property(x => x.AlteradoPor).HasMaxLength(55);
            builder.Property(x => x.DtAlteracao);

            builder.HasOne(x => x.Origem).WithMany().HasForeignKey(x => x.OrigemId);
        }
    }
}
