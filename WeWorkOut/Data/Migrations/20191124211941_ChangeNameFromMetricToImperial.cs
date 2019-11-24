using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Data.Migrations
{
    public partial class ChangeNameFromMetricToImperial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseImperialUnits",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "UseMetricUnits",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseMetricUnits",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "UseImperialUnits",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
