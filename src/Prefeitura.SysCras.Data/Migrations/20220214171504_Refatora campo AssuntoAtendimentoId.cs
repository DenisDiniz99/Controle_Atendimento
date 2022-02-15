using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prefeitura.SysCras.Data.Migrations
{
    public partial class RefatoracampoAssuntoAtendimentoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "AssuntoId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssuntoAtendimentoId",
                table: "Atendimentos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos",
                column: "AssuntoAtendimentoId",
                principalTable: "AssuntoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<Guid>(
                name: "AssuntoAtendimentoId",
                table: "Atendimentos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AssuntoId",
                table: "Atendimentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_AssuntoAtendimentos_AssuntoAtendimentoId",
                table: "Atendimentos",
                column: "AssuntoAtendimentoId",
                principalTable: "AssuntoAtendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
