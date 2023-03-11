﻿// <auto-generated />
using System;
using Enoca.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Enoca.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230310215524_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Enoca.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("OrderFinishTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("OrderStartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6196),
                            IsStatus = true,
                            Name = "Company A",
                            OrderFinishTime = new TimeSpan(0, 17, 0, 0, 0),
                            OrderStartTime = new TimeSpan(0, 9, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6211),
                            IsStatus = true,
                            Name = "Company B",
                            OrderFinishTime = new TimeSpan(0, 16, 0, 0, 0),
                            OrderStartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6213),
                            IsStatus = false,
                            Name = "Company C",
                            OrderFinishTime = new TimeSpan(0, 18, 0, 0, 0),
                            OrderStartTime = new TimeSpan(0, 8, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Enoca.Core.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrdererName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrdererName = "Ali",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrdererName = "Veli",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrdererName = "Ahmet",
                            ProductId = 5
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrdererName = "Mehmet",
                            ProductId = 6
                        });
                });

            modelBuilder.Entity("Enoca.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6406),
                            Name = "Product A1",
                            Price = 50m,
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6410),
                            Name = "Product A2",
                            Price = 75m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6412),
                            Name = "Product B1",
                            Price = 30m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6413),
                            Name = "Product B2",
                            Price = 40m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 3,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6414),
                            Name = "Product C1",
                            Price = 90m,
                            Stock = 8
                        },
                        new
                        {
                            Id = 6,
                            CompanyId = 3,
                            CreatedDate = new DateTime(2023, 3, 11, 0, 55, 23, 876, DateTimeKind.Local).AddTicks(6416),
                            Name = "Product C2",
                            Price = 80m,
                            Stock = 12
                        });
                });

            modelBuilder.Entity("Enoca.Core.Models.Order", b =>
                {
                    b.HasOne("Enoca.Core.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Enoca.Core.Models.Product", b =>
                {
                    b.HasOne("Enoca.Core.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Enoca.Core.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Enoca.Core.Models.Product", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
