﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeWorkOut.Data;

namespace WeWorkOut.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20191201202844_ExerciseChange")]
    partial class ExerciseChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeWorkOut.Models.Exercise", b =>
                {
                    b.Property<int>("ExerciseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("DistanceMeasurementsValid")
                        .HasColumnType("bit");

                    b.Property<string>("HTMLDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RepMeasurementsValid")
                        .HasColumnType("bit");

                    b.Property<bool>("TimeMeasurementsValid")
                        .HasColumnType("bit");

                    b.Property<bool>("WeightMeasurementsValid")
                        .HasColumnType("bit");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("WeWorkOut.Models.ExerciseRecord", b =>
                {
                    b.Property<int>("ExerciseRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("DistanceQuantity")
                        .HasColumnType("float");

                    b.Property<int>("ExcerciseID")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<double?>("RepQuantity")
                        .HasColumnType("float");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("TimeQuantity")
                        .HasColumnType("float");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("WeightQuantity")
                        .HasColumnType("float");

                    b.HasKey("ExerciseRecordID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("ExerciseRecord");
                });

            modelBuilder.Entity("WeWorkOut.Models.Goal", b =>
                {
                    b.Property<int?>("GoalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<double>("MeasurementQuantity")
                        .HasColumnType("float");

                    b.Property<string>("MeasurementType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GoalID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("WeWorkOut.Models.ExerciseRecord", b =>
                {
                    b.HasOne("WeWorkOut.Models.Exercise", "Exercise")
                        .WithMany("ExerciseRecords")
                        .HasForeignKey("ExerciseID");
                });

            modelBuilder.Entity("WeWorkOut.Models.Goal", b =>
                {
                    b.HasOne("WeWorkOut.Models.Exercise", "Exercise")
                        .WithMany("Goals")
                        .HasForeignKey("ExerciseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
