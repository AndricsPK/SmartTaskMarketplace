﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserService;

#nullable disable

namespace UserService.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserService.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Startup founder",
                            Email = "alice@example.com",
                            Role = "client",
                            Username = "alice"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Tech blogger",
                            Email = "bob@example.com",
                            Role = "client",
                            Username = "bob"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Full-stack developer",
                            Email = "carol@example.com",
                            Role = "freelancer",
                            Username = "carol"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
