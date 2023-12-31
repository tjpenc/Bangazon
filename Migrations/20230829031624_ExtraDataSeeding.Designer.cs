﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20230829031624_ExtraDataSeeding")]
    partial class ExtraDataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Catz"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sport"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hiking"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dogz"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeSubmitted")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = "1",
                            IsOpen = true,
                            PaymentTypeId = 3,
                            TimeSubmitted = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8419)
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = "2",
                            IsOpen = true,
                            PaymentTypeId = 2,
                            TimeSubmitted = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8493)
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = "2",
                            IsOpen = false,
                            PaymentTypeId = 2,
                            TimeSubmitted = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8498)
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = "4",
                            IsOpen = false,
                            PaymentTypeId = 2,
                            TimeSubmitted = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8502)
                        },
                        new
                        {
                            Id = 6,
                            CustomerId = "4",
                            IsOpen = false,
                            PaymentTypeId = 2,
                            TimeSubmitted = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8507)
                        });
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Visa"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Mastercard"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Barter System"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeCreated")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A new dog",
                            Name = "Dog",
                            Price = 12,
                            Quantity = 1,
                            SellerId = "123",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8588)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Description = "A new cat",
                            Name = "Cat",
                            Price = 13,
                            Quantity = 1,
                            SellerId = "123",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8666)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "A new tent",
                            Name = "Tent",
                            Price = 200,
                            Quantity = 5,
                            SellerId = "2",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8672)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "New boots",
                            Name = "Hiking Boots",
                            Price = 150,
                            Quantity = 2,
                            SellerId = "2",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8678)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "A new lantern",
                            Name = "Lantern",
                            Price = 40,
                            Quantity = 20,
                            SellerId = "3",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8683)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "A new baseball",
                            Name = "Baseball",
                            Price = 15,
                            Quantity = 1,
                            SellerId = "3",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8688)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            Description = "A new football",
                            Name = "Football",
                            Price = 10,
                            Quantity = 20,
                            SellerId = "3",
                            TimeCreated = new DateTime(2023, 8, 28, 23, 16, 24, 251, DateTimeKind.Local).AddTicks(8692)
                        });
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "123",
                            Email = "amogus@email.com",
                            IsSeller = true,
                            Name = "Amogus"
                        },
                        new
                        {
                            Id = "2",
                            Email = "hammy@email.com",
                            IsSeller = true,
                            Name = "Hammy"
                        },
                        new
                        {
                            Id = "3",
                            Email = "sandra@email.com",
                            IsSeller = true,
                            Name = "Sandra"
                        },
                        new
                        {
                            Id = "4",
                            Email = "crystal@email.com",
                            IsSeller = false,
                            Name = "Crystal"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.OrderProduct", b =>
                {
                    b.HasOne("Bangazon.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
