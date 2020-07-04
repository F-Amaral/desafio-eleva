using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class DisciplinaEscolaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Escolas_EscolaId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professores_ProfessorId",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Turmas_TurmaId",
                table: "Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplina",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina");

            migrationBuilder.RenameTable(
                name: "Disciplina",
                newName: "Disciplinas");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplina_TurmaId",
                table: "Disciplinas",
                newName: "IX_Disciplinas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplina_EscolaId",
                table: "Disciplinas",
                newName: "IX_Disciplinas_EscolaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Disciplinas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Disciplinas",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplinas",
                table: "Disciplinas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Escolas_EscolaId",
                table: "Disciplinas",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Escolas_EscolaId",
                table: "Disciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplinas",
                table: "Disciplinas");

            migrationBuilder.RenameTable(
                name: "Disciplinas",
                newName: "Disciplina");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplinas_TurmaId",
                table: "Disciplina",
                newName: "IX_Disciplina_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplinas_EscolaId",
                table: "Disciplina",
                newName: "IX_Disciplina_EscolaId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "Disciplina",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EscolaId",
                table: "Disciplina",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplina",
                table: "Disciplina",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Escolas_EscolaId",
                table: "Disciplina",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professores_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Turmas_TurmaId",
                table: "Disciplina",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
