using Microsoft.EntityFrameworkCore.Migrations;

namespace team_manager2.Migrations
{
    public partial class Relacao_equipefuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipe_id",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Funcionarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EquipeId",
                table: "Funcionarios",
                column: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Equipes_EquipeId",
                table: "Funcionarios",
                column: "EquipeId",
                principalTable: "Equipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Equipes_EquipeId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_EquipeId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "Equipe_id",
                table: "Funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
