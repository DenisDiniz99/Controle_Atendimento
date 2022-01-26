using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class AlteracamposEntidadeColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNasc",
                table: "Colaboradores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Pasep",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Colaboradores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNasc",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Pasep",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Colaboradores");
        }
    }
}
