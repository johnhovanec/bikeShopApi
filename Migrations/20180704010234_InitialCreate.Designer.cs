﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bikeShopApi.Models;

namespace bikeShopApi.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20180704010234_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

            modelBuilder.Entity("bikeShopApi.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("bikeShopApi.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ShoppingCartID");

                    b.Property<decimal>("Subtotal");

                    b.Property<decimal>("Tax");

                    b.Property<decimal>("Total");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ShoppingCartID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("bikeShopApi.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderID");

                    b.Property<decimal>("Price");

                    b.Property<int>("QuantityAvailable");

                    b.Property<int?>("ShoppingCartID");

                    b.Property<string>("Size");

                    b.Property<int?>("Type");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ShoppingCartID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("bikeShopApi.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.Property<DateTime>("Date");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("bikeShopApi.Models.Order", b =>
                {
                    b.HasOne("bikeShopApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bikeShopApi.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bikeShopApi.Models.Product", b =>
                {
                    b.HasOne("bikeShopApi.Models.Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderID");

                    b.HasOne("bikeShopApi.Models.ShoppingCart")
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartID");
                });

            modelBuilder.Entity("bikeShopApi.Models.ShoppingCart", b =>
                {
                    b.HasOne("bikeShopApi.Models.Customer", "Customer")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
