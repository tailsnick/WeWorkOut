using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class AddRepUnitsAndQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepQuantity",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepUnits",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsRepMeasurements",
                table: "Exercise",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepQuantity",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "RepUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "AcceptsRepMeasurements",
                table: "Exercise");
        }
    }
}
