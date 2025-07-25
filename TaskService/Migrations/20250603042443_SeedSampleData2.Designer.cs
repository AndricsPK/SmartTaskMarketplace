﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskService;

#nullable disable

namespace TaskService.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20250603042443_SeedSampleData2")]
    partial class SeedSampleData2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TaskService.Models.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FreelancerId")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = "1",
                            Description = "Need a logo for my startup",
                            Status = "Open",
                            Title = "Design a logo"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = "2",
                            Description = "CSS issues on homepage",
                            FreelancerId = "3",
                            Status = "In Progress",
                            Title = "Fix website bug"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
