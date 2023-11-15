using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLirios.Migrations
{
    /// <inheritdoc />
    public partial class CriaUsuarioPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePerfil = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoPerfil = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<byte>(type: "tinyint", nullable: false),
                    PasswordSalt = table.Column<byte>(type: "tinyint", nullable: false),
                    DtCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<int>(type: "int", nullable: false),
                    IdPerfil = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
