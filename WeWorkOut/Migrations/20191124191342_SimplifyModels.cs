using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class SimplifyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetMeasurementQuantity",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "TargetMeasurementUnits",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "DistanceUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "RepUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "TimeUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "WeightUnits",
                table: "ExerciseRecord");

            migrationBuilder.DropColumn(
                name: "AcceptsDistanceMeasurements",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AcceptsRepMeasurements",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AcceptsTimeMeasurements",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "AcceptsWeightMeasurements",
                table: "Exercise");

            migrationBuilder.AddColumn<double>(
                name: "MeasurementQuantity",
                table: "Goal",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MeasurementType",
                table: "Goal",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DistanceMeasurementsValid",
                table: "Exercise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RepMeasurementsValid",
                table: "Exercise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TimeMeasurementsValid",
                table: "Exercise",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WeightMeasurementsValid",
                table: "Exercise",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementQuantity",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "MeasurementType",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "DistanceMeasurementsValid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "RepMeasurementsValid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "TimeMeasurementsValid",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "WeightMeasurementsValid",
                table: "Exercise");

            migrationBuilder.AddColumn<double>(
                name: "TargetMeasurementQuantity",
                table: "Goal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TargetMeasurementUnits",
                table: "Goal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistanceUnits",
                table: "ExerciseRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepUnits",
                table: "ExerciseRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeUnits",
                table: "ExerciseRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightUnits",
                table: "ExerciseRecord",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsDistanceMeasurements",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsRepMeasurements",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsTimeMeasurements",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptsWeightMeasurements",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
