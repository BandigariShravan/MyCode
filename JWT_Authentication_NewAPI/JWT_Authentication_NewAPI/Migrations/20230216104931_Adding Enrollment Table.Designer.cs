﻿// <auto-generated />
using JWT_Authentication_NewAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JWTAuthenticationNewAPI.Migrations
{
    [DbContext(typeof(StudentDBContext))]
    [Migration("20230216104931_Adding Enrollment Table")]
    partial class AddingEnrollmentTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.AuthenticationResponse", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Token");

                    b.ToTable("AuthenticationResponses1");
                });

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.Course", b =>
                {
                    b.Property<int>("Course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_Id"));

                    b.Property<string>("Course_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Course_Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.Enrollment", b =>
                {
                    b.Property<int>("Enrollment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Enrollment_Id"));

                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.HasKey("Enrollment_Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("Enrollments1");
                });

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.LoginCredentials", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("LoginCredentials1");
                });

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_Id"));

                    b.Property<string>("Student_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Student_Id");

                    b.ToTable("students1");
                });

            modelBuilder.Entity("JWT_Authentication_NewAPI.Models.Enrollment", b =>
                {
                    b.HasOne("JWT_Authentication_NewAPI.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JWT_Authentication_NewAPI.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
