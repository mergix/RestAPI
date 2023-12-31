﻿// <auto-generated />
using System;
using Hotel.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DbContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HotelApp.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("dateIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dateOut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("roomId")
                        .HasColumnType("uuid");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<Guid>("userId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("roomId");

                    b.HasIndex("userId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("HotelApp.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("bookingId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("bookingId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("HotelApp.Models.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<Guid>("bookingId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("paymentDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("paymentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("bookingId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("HotelApp.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("roomNo")
                        .HasColumnType("integer");

                    b.Property<Guid>("roomTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("roomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("HotelApp.Models.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("RoomPicture")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<decimal?>("cost")
                        .HasColumnType("numeric");

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("roomtypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("HotelApp.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("gender")
                        .HasColumnType("integer");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("paymentInfoId")
                        .HasColumnType("uuid");

                    b.Property<long>("phoneNo")
                        .HasColumnType("bigint");

                    b.Property<int>("roleType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("paymentInfoId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HotelApp.Models.Booking", b =>
                {
                    b.HasOne("HotelApp.Models.Room", "room")
                        .WithMany()
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelApp.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");

                    b.Navigation("user");
                });

            modelBuilder.Entity("HotelApp.Models.Order", b =>
                {
                    b.HasOne("HotelApp.Models.Booking", "booking")
                        .WithMany()
                        .HasForeignKey("bookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");
                });

            modelBuilder.Entity("HotelApp.Models.Payment", b =>
                {
                    b.HasOne("HotelApp.Models.Booking", "booking")
                        .WithMany()
                        .HasForeignKey("bookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("booking");
                });

            modelBuilder.Entity("HotelApp.Models.Room", b =>
                {
                    b.HasOne("HotelApp.Models.RoomType", "roomType")
                        .WithMany()
                        .HasForeignKey("roomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("HotelApp.Models.User", b =>
                {
                    b.HasOne("HotelApp.Models.Payment", "paymentInfo")
                        .WithMany()
                        .HasForeignKey("paymentInfoId");

                    b.Navigation("paymentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
