﻿// <auto-generated />
using System;
using LeaveTastic.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeaveTastic.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230121221744_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeaveTastic.Shared.Models.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfLeave")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Employ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Department Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Human Resources Manager"
                        });
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerId = 6,
                            Name = "Employ 1"
                        },
                        new
                        {
                            Id = 2,
                            ManagerId = 6,
                            Name = "Employ 2"
                        },
                        new
                        {
                            Id = 3,
                            ManagerId = 6,
                            Name = "Employ 3"
                        },
                        new
                        {
                            Id = 4,
                            ManagerId = 7,
                            Name = "Employ 4"
                        },
                        new
                        {
                            Id = 5,
                            ManagerId = 8,
                            Name = "Employ 5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Department Manager 1"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Department Manager 2"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Human Resources Manager"
                        });
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.UserLeave", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("LeaveId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "LeaveId");

                    b.HasIndex("LeaveId");

                    b.ToTable("UserLeaves");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 6,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 7,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 8,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.Leave", b =>
                {
                    b.HasOne("LeaveTastic.Shared.Models.User", "User")
                        .WithMany("Leaves")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.UserLeave", b =>
                {
                    b.HasOne("LeaveTastic.Shared.Models.Leave", "Leave")
                        .WithMany()
                        .HasForeignKey("LeaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeaveTastic.Shared.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leave");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.UserRole", b =>
                {
                    b.HasOne("LeaveTastic.Shared.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeaveTastic.Shared.Models.User", "User")
                        .WithOne("Role")
                        .HasForeignKey("LeaveTastic.Shared.Models.UserRole", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LeaveTastic.Shared.Models.User", b =>
                {
                    b.Navigation("Leaves");

                    b.Navigation("Role")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}