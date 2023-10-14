﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLirios.Data;

#nullable disable

namespace SistemaLirios.Migrations
{
    [DbContext(typeof(SistemaLiriosDBContext))]
    [Migration("20231014213456_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SistemaLirios.Models.ClienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("Bloqueado")
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("Celular")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Indicacao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SistemaLirios.Models.GastosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeGasto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recorrente")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("SistemaLirios.Models.OrigemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origem");
                });

            modelBuilder.Entity("SistemaLirios.Models.PrestadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prestador");
                });

            modelBuilder.Entity("SistemaLirios.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("CodigoDeBarra")
                        .HasColumnType("int");

                    b.Property<int>("CodigoOrigem")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(455)
                        .HasColumnType("nvarchar(455)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<float>("ValorCusto")
                        .HasColumnType("real");

                    b.Property<float>("ValorVendaRevista")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("SistemaLirios.Models.ServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipo")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("SistemaLirios.Models.TipoServicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ativo")
                        .HasColumnType("int");

                    b.Property<string>("CadastradoPor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeTipoServico")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoServico");
                });

            modelBuilder.Entity("SistemaLirios.Models.VendaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("CadastradoPor")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<float>("CustoProduto")
                        .HasColumnType("real");

                    b.Property<DateTime>("DtAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtVenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("MetodoPagamento")
                        .HasColumnType("int");

                    b.Property<int>("PreVenda")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("int");

                    b.Property<float>("ValorVenda")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });
#pragma warning restore 612, 618
        }
    }
}
