using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class Retiraenderecodosetor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco_Bairro",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cep",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Endereco_Cidade",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Endereco_Estado",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Endereco_Numero",
                table: "Setores");

            migrationBuilder.DropColumn(
                name: "Endereco_Rua",
                table: "Setores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Endereco_Bairro",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cep",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Cidade",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Estado",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Numero",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_Rua",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
