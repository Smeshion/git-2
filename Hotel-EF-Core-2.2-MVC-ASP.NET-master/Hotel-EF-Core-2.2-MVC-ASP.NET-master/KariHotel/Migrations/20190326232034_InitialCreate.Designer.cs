﻿// <auto-generated />
using System;
using KariHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KariHotel.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20190326232034_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KariHotel.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPhone");

                    b.Property<string>("Email");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Pass");

                    b.HasKey("ClientID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("KariHotel.Models.Orders", b =>
                {
                    b.Property<int>("OrdersID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Check_inDate");

                    b.Property<DateTime>("Check_outDate");

                    b.Property<int>("ClientID");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("RoomID");

                    b.HasKey("OrdersID");

                    b.HasIndex("ClientID");

                    b.HasIndex("RoomID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KariHotel.Models.Room", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("Number");

                    b.Property<string>("Title");

                    b.HasKey("RoomID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("KariHotel.Models.Orders", b =>
                {
                    b.HasOne("KariHotel.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KariHotel.Models.Room", "Room")
                        .WithMany("Orders")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
