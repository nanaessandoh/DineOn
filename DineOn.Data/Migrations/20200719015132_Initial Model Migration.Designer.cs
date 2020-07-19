﻿// <auto-generated />
using System;
using DineOn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DineOn.Data.Migrations
{
    [DbContext(typeof(DineOnDBContext))]
    [Migration("20200719015132_Initial Model Migration")]
    partial class InitialModelMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DineOn.Data.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DineOn.Data.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("DineOn.Data.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DineOn.Data.Models.Rating", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemOnMenuMenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.HasIndex("ItemOnMenuMenuItemId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("DineOn.Data.Models.MenuItem", b =>
                {
                    b.HasOne("DineOn.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("DineOn.Data.Models.Order", null)
                        .WithMany("Cart")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("DineOn.Data.Models.Rating", b =>
                {
                    b.HasOne("DineOn.Data.Models.MenuItem", "ItemOnMenu")
                        .WithMany("Ratings")
                        .HasForeignKey("ItemOnMenuMenuItemId");
                });
#pragma warning restore 612, 618
        }
    }
}
