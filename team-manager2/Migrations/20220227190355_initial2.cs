using Microsoft.EntityFrameworkCore.Migrations;

namespace team_manager2.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Equipe_id",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipe_id",
                table: "Funcionarios");
        }
    }
}
