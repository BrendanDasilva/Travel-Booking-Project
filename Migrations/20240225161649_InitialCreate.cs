using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerNight = table.Column<double>(type: "float", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_CarRentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightBookings",
                columns: table => new
                {
                    FlightBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalAirport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightBookings", x => x.FlightBookingId);
                    table.ForeignKey(
                        name: "FK_FlightBookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarId", "Brand", "IsAvailable", "Model", "PricePerDay", "Year" },
                values: new object[,]
                {
                    { 1, "Honda", true, "Civic Sport", 69.989999999999995, 2019 },
                    { 2, "Toyota", true, "Camry SE", 79.989999999999995, 2020 },
                    { 3, "Ford", true, "Mustang GT", 99.989999999999995, 2018 },
                    { 4, "Chevrolet", true, "Camaro SS", 109.98999999999999, 2021 },
                    { 5, "Nissan", true, "Altima SV", 74.989999999999995, 2020 },
                    { 6, "Hyundai", true, "Sonata Limited", 69.989999999999995, 2019 },
                    { 7, "Kia", true, "Optima EX", 64.989999999999995, 2018 },
                    { 8, "BMW", true, "3 Series", 129.99000000000001, 2020 },
                    { 9, "Mercedes-Benz", true, "C-Class", 139.99000000000001, 2021 },
                    { 10, "Audi", true, "A4 Premium", 119.98999999999999, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "ArrivalAirport", "ArrivalTime", "DepartureAirport", "DepartureTime", "Destination", "Price" },
                values: new object[,]
                {
                    { 1, "Delta Airlines", "JFK", new DateTime(2024, 3, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 3, 15, 7, 30, 0, 0, DateTimeKind.Unspecified), "New York", 350.00m },
                    { 2, "American Airlines", "ORD", new DateTime(2024, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), "MIA", new DateTime(2024, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Chicago", 280.00m },
                    { 3, "United Airlines", "SFO", new DateTime(2024, 4, 5, 10, 30, 0, 0, DateTimeKind.Unspecified), "JFK", new DateTime(2024, 4, 5, 6, 45, 0, 0, DateTimeKind.Unspecified), "San Francisco", 400.00m },
                    { 4, "Southwest Airlines", "LAS", new DateTime(2024, 4, 10, 12, 50, 0, 0, DateTimeKind.Unspecified), "DEN", new DateTime(2024, 4, 10, 11, 15, 0, 0, DateTimeKind.Unspecified), "Las Vegas", 150.00m },
                    { 5, "JetBlue", "BOS", new DateTime(2024, 4, 15, 8, 30, 0, 0, DateTimeKind.Unspecified), "FLL", new DateTime(2024, 4, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), "Boston", 200.00m },
                    { 6, "Alaska Airlines", "SEA", new DateTime(2024, 4, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 4, 20, 16, 0, 0, 0, DateTimeKind.Unspecified), "Seattle", 220.00m },
                    { 7, "Spirit Airlines", "DFW", new DateTime(2024, 5, 1, 16, 45, 0, 0, DateTimeKind.Unspecified), "ATL", new DateTime(2024, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "Dallas", 95.00m },
                    { 8, "Frontier Airlines", "DEN", new DateTime(2024, 5, 10, 20, 35, 0, 0, DateTimeKind.Unspecified), "PHX", new DateTime(2024, 5, 10, 17, 20, 0, 0, DateTimeKind.Unspecified), "Denver", 115.00m },
                    { 9, "Hawaiian Airlines", "HNL", new DateTime(2024, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), "LAX", new DateTime(2024, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "Honolulu", 500.00m },
                    { 10, "British Airways", "LHR", new DateTime(2024, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "JFK", new DateTime(2024, 6, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), "London", 750.00m }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Amenities", "Location", "Name", "PricePerNight", "ServiceType" },
                values: new object[,]
                {
                    { 1, "Yes", "Manhattan, New York", "The Ritz Carlton", 1139.0, "Full Service" },
                    { 2, "Yes", "Manhattan, New York", "The Plaza Hotel", 1780.0, "Full Service" },
                    { 4, "Yes", "Paris, France", "Hotel Louvre Sainte Anne", 291.0, "Full Service" },
                    { 5, "Yes", "Paris, France", "Hotel Brighton", 509.0, "Full Service" },
                    { 6, "Yes", "Paris, France", "Solly Hotel Paris", 383.0, "Full Service" },
                    { 7, "Yes", "Tokyo, Japan", "Grand Hyatt Tokyo", 987.0, "Full Service" },
                    { 8, "Yes", "Tokyo, Japan", "The Prince Park Tower", 484.0, "Full Service" },
                    { 9, "Yes", "Tokyo, Japan", "Four Seasons Hotel Tokyo", 1104.0, "Full Service" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarId",
                table: "CarRentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightBookings_FlightId",
                table: "FlightBookings",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "FlightBookings");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
