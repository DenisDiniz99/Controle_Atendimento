using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class AlteratipodecampoProtocolo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Protocolo_NumProtocolo",
                table: "Atendimentos");

            migrationBuilder.AddColumn<int>(
                name: "Protocolo",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Protocolo",
                table: "Atendimentos");

            migrationBuilder.AddColumn<int>(
                name: "Protocolo_NumProtocolo",
                table: "Atendimentos",
                type: "int",
                nullable: true);
        }
    }
}
