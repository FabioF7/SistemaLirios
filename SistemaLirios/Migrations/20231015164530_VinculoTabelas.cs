using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLirios.Migrations
{
    public partial class VinculoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Venda",
                newName: "ProdutoId");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Venda",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "Servico",
                newName: "TipoServicoId");

            migrationBuilder.RenameColumn(
                name: "CodigoOrigem",
                table: "Produto",
                newName: "OrigemId");

            migrationBuilder.RenameColumn(
                name: "IdTipo",
                table: "Prestador",
                newName: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Servico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrigemId",
                table: "Produto",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestador_TipoServicoId",
                table: "Prestador",
                column: "TipoServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestador_TipoServico_TipoServicoId",
                table: "Prestador",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Origem_OrigemId",
                table: "Produto",
                column: "OrigemId",
                principalTable: "Origem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestador_TipoServico_TipoServicoId",
                table: "Prestador");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Origem_OrigemId",
                table: "Produto");

            migrationBuilder.DropForeignKey(
                name: "FK_Servico_TipoServico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteId",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Produto_ProdutoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_ProdutoId",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Servico_TipoServicoId",
                table: "Servico");

            migrationBuilder.DropIndex(
                name: "IX_Produto_OrigemId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Prestador_TipoServicoId",
                table: "Prestador");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Venda",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Venda",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId",
                table: "Servico",
                newName: "IdTipo");

            migrationBuilder.RenameColumn(
                name: "OrigemId",
                table: "Produto",
                newName: "CodigoOrigem");

            migrationBuilder.RenameColumn(
                name: "TipoServicoId",
                table: "Prestador",
                newName: "IdTipo");
        }
    }
}
