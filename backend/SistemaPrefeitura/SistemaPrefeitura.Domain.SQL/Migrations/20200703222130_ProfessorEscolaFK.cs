using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class ProfessorEscolaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Escolas_EscolaId",
                table: "Professor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor",
                table: "Professor");

            migrationBuilder.RenameTable(
                name: "Professor",
                newName: "Professores");

            migrationBuilder.RenameIndex(
                name: "IX_Professor_EscolaId",
                table: "Professores",
                newName: "IX_Professores_EscolaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Professores",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professores",
                table: "Professores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professores_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Escolas_EscolaId",
                table: "Professores",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professores_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Escolas_EscolaId",
                table: "Professores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professores",
                table: "Professores");

            migrationBuilder.RenameTable(
                name: "Professores",
                newName: "Professor");

            migrationBuilder.RenameIndex(
                name: "IX_Professores_EscolaId",
                table: "Professor",
                newName: "IX_Professor_EscolaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Professor",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor",
                table: "Professor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Escolas_EscolaId",
                table: "Professor",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
