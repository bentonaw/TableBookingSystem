using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TableBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsCommunal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    TimeSlotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.TimeSlotId);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MenuItemCategory = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TimeSlotId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    NrOfSeats = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "TimeSlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "MenuItemId", "MenuDescription", "MenuId", "MenuItemCategory", "MenuItemName", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "Original burger made from ...", null, "Main Course", "Burger", 9.9900000000000002, 10 },
                    { 2, "cheese and tomato sauce", null, "Main Course", "Pizza", 12.99, 10 },
                    { 3, "lorem", null, "Appetizer", "Salad", 6.9900000000000002, 10 },
                    { 4, "ipsum", null, "Main Course", "Pasta", 11.99, 10 },
                    { 5, "lorem ipsum", null, "Appetizer", "Soup", 4.9900000000000002, 10 },
                    { 6, "test", null, "Main Course", "Steak", 15.99, 10 },
                    { 7, "test", null, "Main Course", "Fish and Chips", 13.99, 10 },
                    { 8, "test", null, "Main Course", "Sushi", 16.989999999999998, 10 },
                    { 9, "test", null, "Appetizer", "Nachos", 8.9900000000000002, 10 },
                    { 10, "test", null, "Dessert", "Ice Cream", 5.9900000000000002, 10 }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "W.42" },
                    { 2, "W.43" }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "Capacity", "IsCommunal", "TableNumber" },
                values: new object[,]
                {
                    { 1, 8, true, 1 },
                    { 2, 4, false, 2 },
                    { 3, 4, false, 3 },
                    { 4, 2, false, 4 },
                    { 5, 2, false, 5 },
                    { 6, 2, false, 6 }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "TimeSlotId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 13, 15, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 2, new TimeSpan(0, 13, 45, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 3, new TimeSpan(0, 14, 15, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 4, new TimeSpan(0, 14, 45, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 5, new TimeSpan(0, 15, 15, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 6, new TimeSpan(0, 15, 45, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 7, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 8, new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 9, new TimeSpan(0, 20, 30, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 10, new TimeSpan(0, 21, 0, 0, 0), new TimeSpan(0, 19, 0, 0, 0) },
                    { 11, new TimeSpan(0, 21, 30, 0, 0), new TimeSpan(0, 19, 30, 0, 0) },
                    { 12, new TimeSpan(0, 22, 0, 0, 0), new TimeSpan(0, 20, 0, 0, 0) },
                    { 13, new TimeSpan(0, 22, 30, 0, 0), new TimeSpan(0, 20, 30, 0, 0) },
                    { 14, new TimeSpan(0, 22, 30, 0, 0), new TimeSpan(0, 21, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TimeSlotId",
                table: "Reservations",
                column: "TimeSlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "TimeSlots");
        }
    }
}
