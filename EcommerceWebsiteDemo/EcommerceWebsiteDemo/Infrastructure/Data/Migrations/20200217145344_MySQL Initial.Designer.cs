﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;

namespace EcommerceWebsiteDemo.Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20200217145344_MySQL Initial")]
    partial class MySQLInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.OrderAggregate.DeliveryMethod", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("DeliveryTime")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("Description")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("ShortName")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.HasKey("Id");

                b.ToTable("DeliveryMethods");
            });

            modelBuilder.Entity("Core.Entities.OrderAggregate.Order", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("BuyerEmail")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<int?>("DeliveryMethodId")
                    .HasColumnType("int");

                b.Property<DateTimeOffset>("OrderDate")
                    .HasColumnType("datetime(6)");

                b.Property<string>("PaymentIntentId")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("Status")
                    .IsRequired()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<decimal>("Subtotal")
                    .HasColumnType("decimal(65,30)");

                b.HasKey("Id");

                b.HasIndex("DeliveryMethodId");

                b.ToTable("Orders");
            });

            modelBuilder.Entity("Core.Entities.OrderAggregate.OrderItem", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int?>("OrderId")
                    .HasColumnType("int");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("Quantity")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("OrderId");

                b.ToTable("OrderItems");
            });

            modelBuilder.Entity("Core.Entities.Product", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                    .HasMaxLength(100);

                b.Property<string>("PictureUrl")
                    .IsRequired()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<decimal>("Price")
                    .HasColumnType("decimal(18,2)");

                b.Property<int>("ProductBrandId")
                    .HasColumnType("int");

                b.Property<int>("ProductTypeId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ProductBrandId");

                b.HasIndex("ProductTypeId");

                b.ToTable("Products");
            });

            modelBuilder.Entity("Core.Entities.ProductBrand", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.HasKey("Id");

                b.ToTable("ProductBrands");
            });

            modelBuilder.Entity("Core.Entities.ProductType", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.HasKey("Id");

                b.ToTable("ProductTypes");
            });

            modelBuilder.Entity("Core.Entities.OrderAggregate.Order", b =>
            {
                b.HasOne("Core.Entities.OrderAggregate.DeliveryMethod", "DeliveryMethod")
                    .WithMany()
                    .HasForeignKey("DeliveryMethodId");

                b.OwnsOne("Core.Entities.OrderAggregate.Address", "ShipToAddress", b1 =>
                {
                    b1.Property<int>("OrderId")
                        .HasColumnType("int");

                    b1.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<string>("Zipcode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.HasKey("OrderId");

                    b1.ToTable("Orders");

                    b1.WithOwner()
                        .HasForeignKey("OrderId");
                });
            });

            modelBuilder.Entity("Core.Entities.OrderAggregate.OrderItem", b =>
            {
                b.HasOne("Core.Entities.OrderAggregate.Order", null)
                    .WithMany("OrderItems")
                    .HasForeignKey("OrderId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.OwnsOne("Core.Entities.OrderAggregate.ProductItemOrdered", "ItemOrdered", b1 =>
                {
                    b1.Property<int>("OrderItemId")
                        .HasColumnType("int");

                    b1.Property<string>("PictureUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.Property<int>("ProductItemId")
                        .HasColumnType("int");

                    b1.Property<string>("ProductName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b1.HasKey("OrderItemId");

                    b1.ToTable("OrderItems");

                    b1.WithOwner()
                        .HasForeignKey("OrderItemId");
                });
            });

            modelBuilder.Entity("Core.Entities.Product", b =>
            {
                b.HasOne("Core.Entities.ProductBrand", "ProductBrand")
                    .WithMany()
                    .HasForeignKey("ProductBrandId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Core.Entities.ProductType", "ProductType")
                    .WithMany()
                    .HasForeignKey("ProductTypeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
