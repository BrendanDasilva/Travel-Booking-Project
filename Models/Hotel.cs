using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
  public class Hotel
  {
    [Key]
    public int HotelId { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public double PricePerNight { get; set; }
    public string Amenities { get; set; }
    
    public string ServiceType { get; set; }


        //BOOKING
  }
}
