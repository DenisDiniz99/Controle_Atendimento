using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class AlteracaodeEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Colaboradores",
                newName: "Situacao");

            migrationBuilder.RenameColumn(
                name: "HoraAtend",
                table: "Atendimentos",
                newName: "HoraAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DataAtend",
                table: "Atendimentos",
                newName: "HoraAtendimento");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cidadaos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nis",
                table: "Cidadaos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Situacao",
                table: "Cidadaos",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cidadaos");

            migrationBuilder.DropColumn(
                name: "Nis",
                table: "Cidadaos");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Cidadaos");

            migrationBuilder.DropColumn(
                name: "DataAtendimento",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Atendimentos");

            migrationBuilder.RenameColumn(
                name: "Situacao",
                table: "Colaboradores",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "HoraAtualizacao",
                table: "Atendimentos",
                newName: "HoraAtend");

            migrationBuilder.RenameColumn(
                name: "HoraAtendimento",
                table: "Atendimentos",
                newName: "DataAtend");
        }
    }
}
