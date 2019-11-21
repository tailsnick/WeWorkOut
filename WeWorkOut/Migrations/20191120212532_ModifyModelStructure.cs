using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class ModifyModelStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.AddColumn<int>(
                name: "DistanceQuantity",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistanceUnits",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeQuantity",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeUnits",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeightQuantity",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightUnits",
                table: "ExerciseRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsDistanceMeasurements",
                table: "Exercise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsTimeMeasurements",
                table: "Exercise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsWeightMeasurements",
                table: "Exercise",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistanceQuantity",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "DistanceUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "TimeQuantity",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "TimeUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "WeightQuantity",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "WeightUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "AcceptsDistanceMeasurements",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AcceptsTimeMeasurements",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AcceptsWeightMeasurements",
                table: "Exercise");

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseRecordID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Units = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.MeasurementID);
                    table.ForeignKey(
                        name: "FK_Measurement_ExerciseRecord_ExerciseRecordID",
                        column: x => x.ExerciseRecordID,
                        principalTable: "ExerciseRecord",
                        principalColumn: "ExerciseRecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_ExerciseRecordID",
                table: "Measurement",
                column: "ExerciseRecordID");
        }
    }
}
