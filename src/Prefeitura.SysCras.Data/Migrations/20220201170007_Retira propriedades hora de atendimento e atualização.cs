using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class Retirapropriedadeshoradeatendimentoeatualização : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtendimento",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Atendimentos");

            migrationBuilder.RenameColumn(
                name: "HoraAtualizacao",
                table: "Atendimentos",
                newName: "DataHoraAtualizacao");

            migrationBuilder.RenameColumn(
                name: "HoraAtendimento",
                table: "Atendimentos",
                newName: "DataHoraAtendimento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHoraAtualizacao",
                table: "Atendimentos",
                newName: "HoraAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DataHoraAtendimento",
                table: "Atendimentos",
                newName: "HoraAtendimento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtendimento",
                table: "Atendimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Atendimentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
