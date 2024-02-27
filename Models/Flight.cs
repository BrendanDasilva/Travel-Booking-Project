using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
  public class Flight
  {
    [Key]
    public int FlightId { get; set; }

    [Required, StringLength(50)]
    public string Airline { get; set; }

    [Required, StringLength(100)]
    public string Destination { get; set; }

    [Required, Display(Name = "Departure Airport")]
    public string DepartureAirport { get; set; }

    [Required, Display(Name = "Arrival Airport")]
    public string ArrivalAirport { get; set; }

    [Required, Display(Name = "Departure Time"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime DepartureTime { get; set; }

    [Required, Display(Name = "Arrival Time"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime ArrivalTime { get; set; }

    [Required, DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }
  }
}
