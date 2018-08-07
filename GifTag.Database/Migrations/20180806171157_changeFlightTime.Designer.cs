﻿// <auto-generated />
using System;
using GifTag.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GifTag.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180806171157_changeFlightTime")]
    partial class changeFlightTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GifTag.Database.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirlineCode");

                    b.Property<string>("AirlineName");

                    b.Property<string>("Class");

                    b.Property<string>("FirstName");

                    b.Property<string>("FlightDate");

                    b.Property<string>("FlightNumber");

                    b.Property<string>("FlightTime");

                    b.Property<string>("FromCode");

                    b.Property<string>("FromName");

                    b.Property<string>("Gate");

                    b.Property<string>("GeneratedTicket");

                    b.Property<bool>("IsPaid");

                    b.Property<string>("Language");

                    b.Property<string>("LastName");

                    b.Property<string>("Seat");

                    b.Property<string>("Template");

                    b.Property<string>("ToCode");

                    b.Property<string>("ToName");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GifTag.Database.Ticket", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}