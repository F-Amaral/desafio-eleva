using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class AlunoEscolaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Alunos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos");

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Alunos",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
