using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class turmasDisciplinasFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Professores_ProfessorId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas");
        }
    }
}
