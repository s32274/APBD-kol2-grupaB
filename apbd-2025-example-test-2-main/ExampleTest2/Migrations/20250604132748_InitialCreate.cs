﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExampleTest2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    ConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.ConcertId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Ticket_Concert",
                columns: table => new
                {
                    TicketConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket_Concert", x => x.TicketConcertId);
                    table.ForeignKey(
                        name: "FK_Ticket_Concert_Status_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Status",
                        principalColumn: "ConcertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Concert_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchased_Ticket",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TicketConcertId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchased_Ticket", x => new { x.TicketConcertId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Purchased_Ticket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchased_Ticket_Ticket_Concert_TicketConcertId",
                        column: x => x.TicketConcertId,
                        principalTable: "Ticket_Concert",
                        principalColumn: "TicketConcertId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "John", "Doe", "12345678" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "ConcertId", "AvailableTickets", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 20, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concert 1" },
                    { 2, 30, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Concert 2" }
                });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "TicketId", "SeatNumber", "SerialNumber" },
                values: new object[,]
                {
                    { 1, 1, "123" },
                    { 2, 2, "456" },
                    { 3, 3, "789" }
                });

            migrationBuilder.InsertData(
                table: "Ticket_Concert",
                columns: new[] { "TicketConcertId", "ConcertId", "Price", "TicketId" },
                values: new object[,]
                {
                    { 1, 1, 33.4m, 1 },
                    { 2, 2, 33.4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Purchased_Ticket",
                columns: new[] { "CustomerId", "TicketConcertId", "PurchaseDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchased_Ticket_CustomerId",
                table: "Purchased_Ticket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Concert_ConcertId",
                table: "Ticket_Concert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Concert_TicketId",
                table: "Ticket_Concert",
                column: "TicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchased_Ticket");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Ticket_Concert");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
