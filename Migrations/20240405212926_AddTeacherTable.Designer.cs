﻿// <auto-generated />
using System;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240405212926_AddTeacherTable")]
    partial class AddTeacherTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("EntityFrameworkCore.Data.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.CourseRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseRegistrations");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AugurationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("SurName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Course", b =>
                {
                    b.HasOne("EntityFrameworkCore.Data.Teacher", "Teacher")
                        .WithMany("CourseRegistrations")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.CourseRegistration", b =>
                {
                    b.HasOne("EntityFrameworkCore.Data.Course", "Course")
                        .WithMany("CourseRegistrations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCore.Data.Student", "Student")
                        .WithMany("CourseRegistrations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Course", b =>
                {
                    b.Navigation("CourseRegistrations");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Student", b =>
                {
                    b.Navigation("CourseRegistrations");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Teacher", b =>
                {
                    b.Navigation("CourseRegistrations");
                });
#pragma warning restore 612, 618
        }
    }
}
