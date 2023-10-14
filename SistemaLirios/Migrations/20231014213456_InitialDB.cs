using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLirios.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Indicacao = table.Column<int>(type: "int", nullable: false),
                    Bloqueado = table.Column<int>(type: "int", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGasto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Recorrente = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false),
                    CodigoOrigem = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CodigoDeBarra = table.Column<int>(type: "int", nullable: false),
                    ValorCusto = table.Column<float>(type: "real", nullable: false),
                    ValorVendaRevista = table.Column<float>(type: "real", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoServico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorVenda = table.Column<float>(type: "real", nullable: false),
                    DtVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    CustoProduto = table.Column<float>(type: "real", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    TipoTransacao = table.Column<int>(type: "int", nullable: false),
                    CadastradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: false),
                    PreVenda = table.Column<int>(type: "int", nullable: false),
                    AlteradoPor = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Origem");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "TipoServico");

            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
