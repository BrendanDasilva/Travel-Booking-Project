using Microsoft.EntityFrameworkCore;
using Assignment1.Models;

namespace Assignment1.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; }
    public DbSet<FlightBooking> FlightBookings { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Cars> Cars { get; set; }
    public DbSet<CarRental> CarRentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Flight>().HasData(
          new Flight
          {
            FlightId = 1,
            Airline = "Delta Airlines",
            Destination = "New York",
            DepartureAirport = "LAX",
            ArrivalAirport = "JFK",
            DepartureTime = new DateTime(2024, 3, 15, 7, 30, 0),
            ArrivalTime = new DateTime(2024, 3, 15, 15, 45, 0),
            Price = 350.00M
          },
          new Flight
          {
            FlightId = 2,
            Airline = "American Airlines",
            Destination = "Chicago",
            DepartureAirport = "MIA",
            ArrivalAirport = "ORD",
            DepartureTime = new DateTime(2024, 3, 20, 9, 00, 0),
            ArrivalTime = new DateTime(2024, 3, 20, 12, 00, 0),
            Price = 280.00M
          },
          new Flight
          {
            FlightId = 3,
            Airline = "United Airlines",
            Destination = "San Francisco",
            DepartureAirport = "JFK",
            ArrivalAirport = "SFO",
            DepartureTime = new DateTime(2024, 4, 5, 6, 45, 0),
            ArrivalTime = new DateTime(2024, 4, 5, 10, 30, 0),
            Price = 400.00M
          },
          new Flight
          {
            FlightId = 4,
            Airline = "Southwest Airlines",
            Destination = "Las Vegas",
            DepartureAirport = "DEN",
            ArrivalAirport = "LAS",
            DepartureTime = new DateTime(2024, 4, 10, 11, 15, 0),
            ArrivalTime = new DateTime(2024, 4, 10, 12, 50, 0),
            Price = 150.00M
          },
          new Flight
          {
            FlightId = 5,
            Airline = "JetBlue",
            Destination = "Boston",
            DepartureAirport = "FLL",
            ArrivalAirport = "BOS",
            DepartureTime = new DateTime(2024, 4, 15, 5, 00, 0),
            ArrivalTime = new DateTime(2024, 4, 15, 8, 30, 0),
            Price = 200.00M
          },
          new Flight
          {
            FlightId = 6,
            Airline = "Alaska Airlines",
            Destination = "Seattle",
            DepartureAirport = "LAX",
            ArrivalAirport = "SEA",
            DepartureTime = new DateTime(2024, 4, 20, 16, 00, 0),
            ArrivalTime = new DateTime(2024, 4, 20, 19, 00, 0),
            Price = 220.00M
          },
          new Flight
          {
            FlightId = 7,
            Airline = "Spirit Airlines",
            Destination = "Dallas",
            DepartureAirport = "ATL",
            ArrivalAirport = "DFW",
            DepartureTime = new DateTime(2024, 5, 1, 14, 30, 0),
            ArrivalTime = new DateTime(2024, 5, 1, 16, 45, 0),
            Price = 95.00M
          },
          new Flight
          {
            FlightId = 8,
            Airline = "Frontier Airlines",
            Destination = "Denver",
            DepartureAirport = "PHX",
            ArrivalAirport = "DEN",
            DepartureTime = new DateTime(2024, 5, 10, 17, 20, 0),
            ArrivalTime = new DateTime(2024, 5, 10, 20, 35, 0),
            Price = 115.00M
          },
          new Flight
          {
            FlightId = 9,
            Airline = "Hawaiian Airlines",
            Destination = "Honolulu",
            DepartureAirport = "LAX",
            ArrivalAirport = "HNL",
            DepartureTime = new DateTime(2024, 5, 15, 8, 00, 0),
            ArrivalTime = new DateTime(2024, 5, 15, 11, 00, 0),
            Price = 500.00M
          },
          new Flight
          {
            FlightId = 10,
            Airline = "British Airways",
            Destination = "London",
            DepartureAirport = "JFK",
            ArrivalAirport = "LHR",
            DepartureTime = new DateTime(2024, 6, 1, 22, 00, 0),
            ArrivalTime = new DateTime(2024, 6, 2, 10, 00, 0),
            Price = 750.00M
          }
      );

      // Seed data for Cars
      modelBuilder.Entity<Cars>().HasData(
          new Cars { CarId = 1, Brand = "Honda", Model = "Civic Sport", Year = 2019, PricePerDay = 69.99, IsAvailable = true },
          new Cars { CarId = 2, Brand = "Toyota", Model = "Camry SE", Year = 2020, PricePerDay = 79.99, IsAvailable = true },
          new Cars { CarId = 3, Brand = "Ford", Model = "Mustang GT", Year = 2018, PricePerDay = 99.99, IsAvailable = true },
          new Cars { CarId = 4, Brand = "Chevrolet", Model = "Camaro SS", Year = 2021, PricePerDay = 109.99, IsAvailable = true },
          new Cars { CarId = 5, Brand = "Nissan", Model = "Altima SV", Year = 2020, PricePerDay = 74.99, IsAvailable = true },
          new Cars { CarId = 6, Brand = "Hyundai", Model = "Sonata Limited", Year = 2019, PricePerDay = 69.99, IsAvailable = true },
          new Cars { CarId = 7, Brand = "Kia", Model = "Optima EX", Year = 2018, PricePerDay = 64.99, IsAvailable = true },
          new Cars { CarId = 8, Brand = "BMW", Model = "3 Series", Year = 2020, PricePerDay = 129.99, IsAvailable = true },
          new Cars { CarId = 9, Brand = "Mercedes-Benz", Model = "C-Class", Year = 2021, PricePerDay = 139.99, IsAvailable = true },
          new Cars { CarId = 10, Brand = "Audi", Model = "A4 Premium", Year = 2019, PricePerDay = 119.99, IsAvailable = true }
      );

      // Seed data for Hotels
      modelBuilder.Entity<Hotel>().HasData(
          new Hotel { HotelId = 1, Name = "The Ritz Carlton", Amenities = "Yes", Location = "Manhattan, New York", PricePerNight = 1139, ServiceType = "Full Service" },
          new Hotel { HotelId = 2, Name = "The Plaza Hotel", Amenities = "Yes", Location = "Manhattan, New York", PricePerNight = 1780, ServiceType = "Full Service" },
          new Hotel { HotelId = 4, Name = "Hotel Louvre Sainte Anne", Amenities = "Yes", Location = "Paris, France", PricePerNight = 291, ServiceType = "Full Service" },
          new Hotel { HotelId = 5, Name = "Hotel Brighton", Amenities = "Yes", Location = "Paris, France", PricePerNight = 509, ServiceType = "Full Service" },
          new Hotel { HotelId = 6, Name = "Solly Hotel Paris", Amenities = "Yes", Location = "Paris, France", PricePerNight = 383, ServiceType = "Full Service" },
          new Hotel { HotelId = 7, Name = "Grand Hyatt Tokyo", Amenities = "Yes", Location = "Tokyo, Japan", PricePerNight = 987, ServiceType = "Full Service" },
          new Hotel { HotelId = 8, Name = "The Prince Park Tower", Amenities = "Yes", Location = "Tokyo, Japan", PricePerNight = 484, ServiceType = "Full Service" },
          new Hotel { HotelId = 9, Name = "Four Seasons Hotel Tokyo", Amenities = "Yes", Location = "Tokyo, Japan", PricePerNight = 1104, ServiceType = "Full Service" }
      );

    }
  }
}
