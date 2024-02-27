using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
  public class FlightBooking
  {
    [Key]
    public int FlightBookingId { get; set; }

    // Added Foreign key for Flight
    public int FlightId { get; set; }

    // Navigation property for Flight
    public virtual Flight Flight { get; set; }

    // Existing properties
    public string Airline { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    // Customer details
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime BookingDate { get; set; }
  }
}
