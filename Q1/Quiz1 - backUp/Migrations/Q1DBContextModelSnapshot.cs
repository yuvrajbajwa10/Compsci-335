﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz1.Data;

namespace Quiz1.Migrations
{
    [DbContext(typeof(Q1DBContext))]
    partial class Q1DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Quiz1.Models.Courses", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("End1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("End2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Start1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Start2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Weekday1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Weekday2")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Quiz1.Models.Enrolments", b =>
                {
                    b.Property<int>("EnrolmentNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnrolmentNum");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("Quiz1.Models.Marks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("A1")
                        .HasColumnType("REAL");

                    b.Property<float>("A2")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Quiz1.Models.Staff", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Quiz1.Models.Students", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
