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
    [Migration("20191120194527_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExerciseID");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("WeWorkOut.Models.ExerciseRecord", b =>
                {
                    b.Property<int>("ExerciseRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExcerciseID")
                        .HasColumnType("int");

                    b.Property<int?>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ExerciseRecordID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("ExerciseRecord");
                });

            modelBuilder.Entity("WeWorkOut.Models.Goal", b =>
                {
                    b.Property<int>("GoalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Completed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExerciseID")
                        .HasColumnType("int");

                    b.Property<int>("TargetMeasurementQuantity")
                        .HasColumnType("int");

                    b.Property<string>("TargetMeasurementUnits")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GoalID");

                    b.HasIndex("ExerciseID");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("WeWorkOut.Models.Measurement", b =>
                {
                    b.Property<int>("MeasurementID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExerciseRecordID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeasurementID");

                    b.HasIndex("ExerciseRecordID");

                    b.ToTable("Measurement");
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

            modelBuilder.Entity("WeWorkOut.Models.Measurement", b =>
                {
                    b.HasOne("WeWorkOut.Models.ExerciseRecord", "ExerciseRecord")
                        .WithMany("Measurements")
                        .HasForeignKey("ExerciseRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
