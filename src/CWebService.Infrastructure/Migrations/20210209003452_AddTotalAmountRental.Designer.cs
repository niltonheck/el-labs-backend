﻿// <auto-generated />
using System;
using CWebService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CWebService.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210209003452_AddTotalAmountRental")]
    partial class AddTotalAmountRental
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CWebService.Domain.Entities.Brand", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CWebService.Domain.Entities.Model", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CWebService.Domain.Entities.Rental", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FinalDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InitialDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("REAL");

                    b.Property<long>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CWebService.Domain.Entities.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CostPerHour")
                        .HasColumnType("REAL");

                    b.Property<int>("FuelType")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Plate")
                        .HasColumnType("TEXT");

                    b.Property<double>("TrunkCapacity")
                        .HasColumnType("REAL");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CWebService.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("CWebService.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("CWebService.Domain.Entities.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId");

                    b.Navigation("Brand");

                    b.Navigation("Model");
                });
#pragma warning restore 612, 618
        }
    }
}
