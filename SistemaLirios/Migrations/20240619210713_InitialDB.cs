using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaLirios.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Celular = table.Column<long>(type: "bigint", nullable: true),
                    CEP = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Endereco = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Sexo = table.Column<int>(type: "integer", nullable: false),
                    Indicacao = table.Column<int>(type: "integer", nullable: true),
                    Bloqueado = table.Column<int>(type: "integer", nullable: false),
                    Inadimplencia = table.Column<int>(type: "integer", nullable: false),
                    LimiteInadimplencia = table.Column<double>(type: "double precision", nullable: true),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    TipoEvento = table.Column<string>(type: "text", nullable: true),
                    Produto = table.Column<string>(type: "text", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: true),
                    CustoProduto = table.Column<double>(type: "double precision", nullable: true),
                    Valor = table.Column<double>(type: "double precision", nullable: true),
                    Lucro = table.Column<double>(type: "double precision", nullable: true),
                    DataEvento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Situacao = table.Column<string>(type: "text", nullable: true),
                    Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Concluido = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Contado_por = table.Column<string>(type: "text", nullable: true),
                    Revisado_por = table.Column<string>(type: "text", nullable: true),
                    Obsevacoes = table.Column<string>(type: "text", nullable: true),
                    Contabilizado_Total = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomePerfil = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DescricaoPerfil = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeTipoServico = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    ValorPago = table.Column<double>(type: "double precision", nullable: false),
                    TipoTransacao = table.Column<int>(type: "integer", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "integer", nullable: false),
                    DtPagamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(455)", maxLength: 455, nullable: false),
                    OrigemId = table.Column<int>(type: "integer", nullable: false),
                    Codigo = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    CodigoDeBarra = table.Column<long>(type: "bigint", nullable: true),
                    ValorCusto = table.Column<double>(type: "double precision", nullable: false),
                    ValorVendaRevista = table.Column<double>(type: "double precision", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Origem_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Origem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Usuario = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    IdPerfil = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeGasto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Recorrente = table.Column<int>(type: "integer", nullable: false),
                    TipoServicoId = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gastos_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TipoServicoId = table.Column<int>(type: "integer", nullable: false),
                    Local = table.Column<string>(type: "character varying(455)", maxLength: 455, nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestador_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoServicoId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servico_TipoServico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "TipoServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventarioDetalhes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdInventario = table.Column<int>(type: "integer", nullable: false),
                    IdProduto = table.Column<int>(type: "integer", nullable: false),
                    Previsao = table.Column<int>(type: "integer", nullable: false),
                    Contabilizado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioDetalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioDetalhes_Inventario_IdInventario",
                        column: x => x.IdInventario,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioDetalhes_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdVenda = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    DtVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    CustoProduto = table.Column<double>(type: "double precision", nullable: false),
                    MetodoPagamento = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    TipoTransacao = table.Column<int>(type: "integer", nullable: false),
                    Lucro = table.Column<double>(type: "double precision", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    PreVenda = table.Column<int>(type: "integer", nullable: false),
                    CadastradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    AlteradoPor = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: true),
                    DtAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venda_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_TipoServicoId",
                table: "Gastos",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioDetalhes_IdInventario",
                table: "InventarioDetalhes",
                column: "IdInventario");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioDetalhes_IdProduto",
                table: "InventarioDetalhes",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_ClienteId",
                table: "Pagamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_TipoServicoId",
                table: "Prestador",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrigemId",
                table: "Produto",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Historico");

            migrationBuilder.DropTable(
                name: "InventarioDetalhes");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Prestador");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "TipoServico");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Origem");
        }
    }
}
