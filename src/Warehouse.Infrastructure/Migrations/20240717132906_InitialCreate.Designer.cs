﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warehouse.Infrastructure.Common;

#nullable disable

namespace Warehouse.Infrastructure.Migrations
{
    [DbContext(typeof(WarehouseDbContext))]
    [Migration("20240717132906_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Warehouse.Domain.Transactions.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid>("WarehouseRackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseRackId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Warehouse.Domain.Warehouses.WarehouseRack", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Rack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WarehouseSizeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseSizeId");

                    b.ToTable("WarehouseRacks");
                });

            modelBuilder.Entity("Warehouse.Domain.WarehousesSize.WarehouseSize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RackQuantity")
                        .HasColumnType("int");

                    b.Property<int>("SectorNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WarehousesSize");
                });

            modelBuilder.Entity("Warehouse.Domain.Workers.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Warehouse.Domain.Transactions.Transaction", b =>
                {
                    b.HasOne("Warehouse.Domain.Products.Product", "Products")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Warehouses.WarehouseRack", "WarehousesRack")
                        .WithMany("Transactions")
                        .HasForeignKey("WarehouseRackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Domain.Workers.Worker", "Workers")
                        .WithMany("Transactions")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("WarehousesRack");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("Warehouse.Domain.Warehouses.WarehouseRack", b =>
                {
                    b.HasOne("Warehouse.Domain.WarehousesSize.WarehouseSize", "WarehousesSize")
                        .WithMany("WarehousesRack")
                        .HasForeignKey("WarehouseSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WarehousesSize");
                });

            modelBuilder.Entity("Warehouse.Domain.Products.Product", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Warehouse.Domain.Warehouses.WarehouseRack", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Warehouse.Domain.WarehousesSize.WarehouseSize", b =>
                {
                    b.Navigation("WarehousesRack");
                });

            modelBuilder.Entity("Warehouse.Domain.Workers.Worker", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
