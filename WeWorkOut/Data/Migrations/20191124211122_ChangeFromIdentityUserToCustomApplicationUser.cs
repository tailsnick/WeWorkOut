using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Data.Migrations
{
    public partial class ChangeFromIdentityUserToCustomApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseImperialUnits",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseImperialUnits",
                table: "AspNetUsers");
        }
    }
}
