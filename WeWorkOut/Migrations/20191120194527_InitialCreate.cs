using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeWorkOut.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseRecord",
                columns: table => new
                {
                    ExerciseRecordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExcerciseID = table.Column<int>(nullable: false),
                    ExerciseID = table.Column<int>(nullable: true),
                    SubmitDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRecord", x => x.ExerciseRecordID);
                    table.ForeignKey(
                        name: "FK_ExerciseRecord_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    GoalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseID = table.Column<int>(nullable: false),
                    TargetMeasurementQuantity = table.Column<int>(nullable: false),
                    TargetMeasurementUnits = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTime>(nullable: true),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.GoalID);
                    table.ForeignKey(
                        name: "FK_Goal_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseRecordID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Units = table.Column<string>(nullable: true)
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
                name: "IX_ExerciseRecord_ExerciseID",
                table: "ExerciseRecord",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_ExerciseID",
                table: "Goal",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_ExerciseRecordID",
                table: "Measurement",
                column: "ExerciseRecordID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropTable(
                name: "ExerciseRecord");

            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}
