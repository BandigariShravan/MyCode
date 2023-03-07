﻿// <auto-generated />
using System;
using BookAPI.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookUserAPI.Migrations
{
    [DbContext(typeof(BookDBContext))]
    partial class BookDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Book_Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Book_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<DateTime>("Published_Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Book_Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookAPI.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_Id"));

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<string>("Full_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Last_Login")
                        .HasColumnType("datetime2");

                    b.HasKey("User_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookUserAPI.Models.BookUser", b =>
                {
                    b.Property<int>("BookUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookUserId"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Book_Id1")
                        .HasColumnType("int");

                    b.Property<int>("User_Id")
                        .HasColumnType("int");

                    b.Property<int?>("User_Id1")
                        .HasColumnType("int");

                    b.HasKey("BookUserId");

                    b.HasIndex("Book_Id1");

                    b.HasIndex("User_Id1");

                    b.ToTable("bookUsers");
                });

            modelBuilder.Entity("BookUserAPI.Models.BookUser", b =>
                {
                    b.HasOne("BookAPI.Models.Book", null)
                        .WithMany("bookUsers")
                        .HasForeignKey("Book_Id1");

                    b.HasOne("BookAPI.Models.User", null)
                        .WithMany("bookUsers")
                        .HasForeignKey("User_Id1");
                });

            modelBuilder.Entity("BookAPI.Models.Book", b =>
                {
                    b.Navigation("bookUsers");
                });

            modelBuilder.Entity("BookAPI.Models.User", b =>
                {
                    b.Navigation("bookUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
