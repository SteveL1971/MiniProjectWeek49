﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniProjectWeek49;

#nullable disable

namespace MiniProjectWeek49.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20221206090707_seedingMobilesAndLaptopstest2")]
    partial class seedingMobilesAndLaptopstest2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiniProjectWeek49.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            OfficeId = 1,
                            PurchaseDate = new DateTime(2018, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            OfficeId = 1,
                            PurchaseDate = new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            OfficeId = 1,
                            PurchaseDate = new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            ItemId = 4,
                            OfficeId = 2,
                            PurchaseDate = new DateTime(2018, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            ItemId = 5,
                            OfficeId = 2,
                            PurchaseDate = new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            ItemId = 6,
                            OfficeId = 2,
                            PurchaseDate = new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            ItemId = 7,
                            OfficeId = 3,
                            PurchaseDate = new DateTime(2017, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            ItemId = 8,
                            OfficeId = 3,
                            PurchaseDate = new DateTime(2018, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            ItemId = 9,
                            OfficeId = 3,
                            PurchaseDate = new DateTime(2019, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            ItemId = 9,
                            OfficeId = 1,
                            PurchaseDate = new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MiniProjectWeek49.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MiniProjectWeek49.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Currency = "EUR",
                            Name = "Spain",
                            Rate = 0.82645000000000002
                        },
                        new
                        {
                            Id = 2,
                            Currency = "USD",
                            Name = "USA",
                            Rate = 1.0
                        },
                        new
                        {
                            Id = 3,
                            Currency = "SEK",
                            Name = "Sweden",
                            Rate = 8.3339999999999996
                        });
                });

            modelBuilder.Entity("MiniProjectWeek49.Laptop", b =>
                {
                    b.HasBaseType("MiniProjectWeek49.Item");

                    b.Property<string>("TargetArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Laptop");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Brand = "HP",
                            Model = "Elitebook",
                            Price = 1423,
                            TargetArea = "Home"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "HP",
                            Model = "Elitebook 2",
                            Price = 970
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Asus",
                            Model = "W234",
                            Price = 1200
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Lenova",
                            Model = "Yoga 730",
                            Price = 835
                        },
                        new
                        {
                            Id = 9,
                            Brand = "Lenova",
                            Model = "Yoga 530",
                            Price = 1030
                        });
                });

            modelBuilder.Entity("MiniProjectWeek49.Mobile", b =>
                {
                    b.HasBaseType("MiniProjectWeek49.Item");

                    b.HasDiscriminator().HasValue("Mobile");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "iPhone",
                            Model = "8",
                            Price = 970
                        },
                        new
                        {
                            Id = 2,
                            Brand = "iPhone",
                            Model = "11",
                            Price = 990
                        },
                        new
                        {
                            Id = 3,
                            Brand = "iphone",
                            Model = "X",
                            Price = 1245
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Motorola",
                            Model = "Razr",
                            Price = 970
                        });
                });

            modelBuilder.Entity("MiniProjectWeek49.Asset", b =>
                {
                    b.HasOne("MiniProjectWeek49.Item", "Item")
                        .WithMany("Assets")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiniProjectWeek49.Office", "Office")
                        .WithMany("Assets")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("MiniProjectWeek49.Item", b =>
                {
                    b.Navigation("Assets");
                });

            modelBuilder.Entity("MiniProjectWeek49.Office", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
