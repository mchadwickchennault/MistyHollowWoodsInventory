﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MistyHollowWoodsInventory.Data;

namespace MistyHollowWoodsInventory.Migrations
{
    [DbContext(typeof(misty_hollowContext))]
    [Migration("20220103211507_ChangeImageToBlob")]
    partial class ChangeImageToBlob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("MistyHollowWoodsInventory.Models.Bowls", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BowlType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(4000)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("Sold")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("WoodSpecies")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Bowls");
                });
#pragma warning restore 612, 618
        }
    }
}
