using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class RestringeOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Cidadaos_CidadaoId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_TiposAtendimentos_TipoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos",
                column: "AssuntoAtendimentoId",
                principalTable: "AssuntoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Cidadaos_CidadaoId",
                table: "Atendimentos",
                column: "CidadaoId",
                principalTable: "Cidadaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_TiposAtendimentos_TipoAtendimentoId",
                table: "Atendimentos",
                column: "TipoAtendimentoId",
                principalTable: "TiposAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Cidadaos_CidadaoId",
                table: "Atendimentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_TiposAtendimentos_TipoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos",
                column: "AssuntoAtendimentoId",
                principalTable: "AssuntoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Cidadaos_CidadaoId",
                table: "Atendimentos",
                column: "CidadaoId",
                principalTable: "Cidadaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_TiposAtendimentos_TipoAtendimentoId",
                table: "Atendimentos",
                column: "TipoAtendimentoId",
                principalTable: "TiposAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
