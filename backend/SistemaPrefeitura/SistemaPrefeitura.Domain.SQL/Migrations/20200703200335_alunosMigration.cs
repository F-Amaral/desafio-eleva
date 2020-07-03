using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class alunosMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Escolas_EscolaId",
                table: "Aluno");

            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno");

            migrationBuilder.RenameTable(
                name: "Aluno",
                newName: "Alunos");

            migrationBuilder.RenameColumn(
                name: "SobreNome",
                table: "Alunos",
                newName: "Sobrenome");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_TurmaId",
                table: "Alunos",
                newName: "IX_Alunos_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Aluno_EscolaId",
                table: "Alunos",
                newName: "IX_Alunos_EscolaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turma_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Escolas_EscolaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turma_TurmaId",
                table: "Alunos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alunos",
                table: "Alunos");

            migrationBuilder.RenameTable(
                name: "Alunos",
                newName: "Aluno");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Aluno",
                newName: "SobreNome");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_TurmaId",
                table: "Aluno",
                newName: "IX_Aluno_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Alunos_EscolaId",
                table: "Aluno",
                newName: "IX_Aluno_EscolaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aluno",
                table: "Aluno",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Escolas_EscolaId",
                table: "Aluno",
                column: "EscolaId",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Turma_TurmaId",
                table: "Aluno",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
