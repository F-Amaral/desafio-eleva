using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    public partial class turmaDisciplinaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_TurmaId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Disciplinas");

            migrationBuilder.CreateTable(
                name: "TurmasDisciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TurmaId = table.Column<Guid>(nullable: false),
                    DisciplinaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmasDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurmasDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TurmasDisciplinas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TurmasDisciplinas_DisciplinaId",
                table: "TurmasDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_TurmasDisciplinas_TurmaId",
                table: "TurmasDisciplinas",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TurmasDisciplinas");

            migrationBuilder.AddColumn<Guid>(
                name: "TurmaId",
                table: "Disciplinas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Turmas_TurmaId",
                table: "Disciplinas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
