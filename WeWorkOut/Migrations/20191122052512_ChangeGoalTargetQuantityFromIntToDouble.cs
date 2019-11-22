using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class ChangeGoalTargetQuantityFromIntToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Exercise_ExerciseID",
                table: "Goal");

            migrationBuilder.AlterColumn<double>(
                name: "TargetMeasurementQuantity",
                table: "Goal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseID",
                table: "Goal",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExcerciseID",
                table: "ExerciseRecord",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Exercise_ExerciseID",
                table: "Goal",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goal_Exercise_ExerciseID",
                table: "Goal");

            migrationBuilder.AlterColumn<int>(
                name: "TargetMeasurementQuantity",
                table: "Goal",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseID",
                table: "Goal",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ExcerciseID",
                table: "ExerciseRecord",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_Exercise_ExerciseID",
                table: "Goal",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
