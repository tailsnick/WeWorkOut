using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class AddUsersToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Goal",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "ExerciseRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ExerciseRecord");
        }
    }
}
