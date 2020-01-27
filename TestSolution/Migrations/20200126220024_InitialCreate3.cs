using Microsoft.EntityFrameworkCore.Migrations;

namespace TestSolution.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lvl4445",
                table: "Folder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lvl4445",
                table: "Folder");
        }
    }
}
