﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TableBookingSystem.Data;

#nullable disable

namespace TableBookingSystem.Migrations
{
    [DbContext(typeof(TableBookingSystemContext))]
    partial class TableBookingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TableBookingSystem.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TableBookingSystem.Models.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MenuId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            MenuName = "W.42"
                        },
                        new
                        {
                            MenuId = 2,
                            MenuName = "W.43"
                        });
                });

            modelBuilder.Entity("TableBookingSystem.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("MenuItemCategory")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MenuItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            MenuDescription = "Original burger made from ...",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Burger",
                            Price = 9.9900000000000002,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 2,
                            MenuDescription = "cheese and tomato sauce",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Pizza",
                            Price = 12.99,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 3,
                            MenuDescription = "lorem",
                            MenuItemCategory = "Appetizer",
                            MenuItemName = "Salad",
                            Price = 6.9900000000000002,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 4,
                            MenuDescription = "ipsum",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Pasta",
                            Price = 11.99,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 5,
                            MenuDescription = "lorem ipsum",
                            MenuItemCategory = "Appetizer",
                            MenuItemName = "Soup",
                            Price = 4.9900000000000002,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 6,
                            MenuDescription = "test",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Steak",
                            Price = 15.99,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 7,
                            MenuDescription = "test",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Fish and Chips",
                            Price = 13.99,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 8,
                            MenuDescription = "test",
                            MenuItemCategory = "Main Course",
                            MenuItemName = "Sushi",
                            Price = 16.989999999999998,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 9,
                            MenuDescription = "test",
                            MenuItemCategory = "Appetizer",
                            MenuItemName = "Nachos",
                            Price = 8.9900000000000002,
                            Quantity = 10
                        },
                        new
                        {
                            MenuItemId = 10,
                            MenuDescription = "test",
                            MenuItemCategory = "Dessert",
                            MenuItemName = "Ice Cream",
                            Price = 5.9900000000000002,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("TableBookingSystem.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NrOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("TableBookingSystem.Models.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<bool>("IsCommunal")
                        .HasColumnType("bit");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 8,
                            IsCommunal = true,
                            TableNumber = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 4,
                            IsCommunal = false,
                            TableNumber = 2
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 4,
                            IsCommunal = false,
                            TableNumber = 3
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 2,
                            IsCommunal = false,
                            TableNumber = 4
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 2,
                            IsCommunal = false,
                            TableNumber = 5
                        },
                        new
                        {
                            TableId = 6,
                            Capacity = 2,
                            IsCommunal = false,
                            TableNumber = 6
                        });
                });

            modelBuilder.Entity("TableBookingSystem.Models.TimeSlot", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeSlotId"));

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("TimeSlotId");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            TimeSlotId = 1,
                            EndTime = new TimeSpan(0, 13, 15, 0, 0),
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 2,
                            EndTime = new TimeSpan(0, 13, 45, 0, 0),
                            StartTime = new TimeSpan(0, 12, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 3,
                            EndTime = new TimeSpan(0, 14, 15, 0, 0),
                            StartTime = new TimeSpan(0, 13, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 4,
                            EndTime = new TimeSpan(0, 14, 45, 0, 0),
                            StartTime = new TimeSpan(0, 13, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 5,
                            EndTime = new TimeSpan(0, 15, 15, 0, 0),
                            StartTime = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 6,
                            EndTime = new TimeSpan(0, 15, 45, 0, 0),
                            StartTime = new TimeSpan(0, 14, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 7,
                            EndTime = new TimeSpan(0, 16, 0, 0, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 8,
                            EndTime = new TimeSpan(0, 20, 0, 0, 0),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 9,
                            EndTime = new TimeSpan(0, 20, 30, 0, 0),
                            StartTime = new TimeSpan(0, 18, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 10,
                            EndTime = new TimeSpan(0, 21, 0, 0, 0),
                            StartTime = new TimeSpan(0, 19, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 11,
                            EndTime = new TimeSpan(0, 21, 30, 0, 0),
                            StartTime = new TimeSpan(0, 19, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 12,
                            EndTime = new TimeSpan(0, 22, 0, 0, 0),
                            StartTime = new TimeSpan(0, 20, 0, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 13,
                            EndTime = new TimeSpan(0, 22, 30, 0, 0),
                            StartTime = new TimeSpan(0, 20, 30, 0, 0)
                        },
                        new
                        {
                            TimeSlotId = 14,
                            EndTime = new TimeSpan(0, 22, 30, 0, 0),
                            StartTime = new TimeSpan(0, 21, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("TableBookingSystem.Models.MenuItem", b =>
                {
                    b.HasOne("TableBookingSystem.Models.Menu", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("TableBookingSystem.Models.Reservation", b =>
                {
                    b.HasOne("TableBookingSystem.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableBookingSystem.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TableBookingSystem.Models.TimeSlot", "Timeslot")
                        .WithMany("Reservations")
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");

                    b.Navigation("Timeslot");
                });

            modelBuilder.Entity("TableBookingSystem.Models.Menu", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("TableBookingSystem.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("TableBookingSystem.Models.TimeSlot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
