using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLirios.Migrations
{
    /// <inheritdoc />
    public partial class AltClienteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "TipoServicoId",
                table: "Gastos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Inadimplencia",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "LimiteInadimplencia",
                table: "Cliente",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_TipoServicoId",
                table: "Gastos",
                column: "TipoServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gastos_TipoServico_TipoServicoId",
                table: "Gastos",
                column: "TipoServicoId",
                principalTable: "TipoServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gastos_TipoServico_TipoServicoId",
                table: "Gastos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Gastos_TipoServicoId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "TipoServicoId",
                table: "Gastos");

            migrationBuilder.DropColumn(
                name: "Inadimplencia",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "LimiteInadimplencia",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id");
        }
    }
}
