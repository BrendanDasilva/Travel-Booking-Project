namespace Assignment1.Models
{
  public class FlightBookingViewModel
  {
    // Flight details
    public string Airline { get; set; }
    public string DepartureAirport { get; set; }
    public string ArrivalAirport { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }

    // Customer details
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime BookingDate { get; set; }
  }
}
