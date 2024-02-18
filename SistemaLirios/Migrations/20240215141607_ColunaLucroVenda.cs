using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaLirios.Migrations
{
    public partial class ColunaLucroVenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<double>(
                name: "Lucro",
                table: "Venda",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "Venda");

        }
    }
}
