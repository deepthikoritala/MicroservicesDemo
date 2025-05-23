﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Orders.DBContexts;

#nullable disable

namespace Orders.Migrations
{
    [DbContext(typeof(OrdersContext))]
    [Migration("20220829064237_ordersmigration")]
    partial class ordersmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Orders.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NoOfItems")
                        .HasColumnType("integer");

                    b.Property<double>("Total")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Electronic Order",
                            Name = "ElectronicOrder",
                            NoOfItems = 3,
                            Total = 100000.0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Dresses",
                            Name = "ClothesOrder",
                            NoOfItems = 9,
                            Total = 70000.0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Grocery Items",
                            Name = "GroceryOrder",
                            NoOfItems = 10,
                            Total = 1000.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
