using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;

namespace Assignment1.Controllers
{
  public class FlightBookingController : Controller
  {
    private readonly ApplicationDbContext _context;

    public FlightBookingController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Book(int flightId)
    {
      var flight = await _context.Flights.FirstOrDefaultAsync(f => f.FlightId == flightId);
      if (flight == null)
      {
        return NotFound();
      }

      var viewModel = new FlightBookingViewModel
      {
        Airline = flight.Airline,
        DepartureAirport = flight.DepartureAirport,
        ArrivalAirport = flight.ArrivalAirport,
        DepartureTime = flight.DepartureTime,
        ArrivalTime = flight.ArrivalTime,
        Price = flight.Price,
        BookingDate = DateTime.Now
      };

      return View("~/Views/FlightBooking/Book.cshtml", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateBooking([Bind("FlightId,CustomerName,CustomerEmail,BookingDate")] FlightBooking booking)
    {
      if (ModelState.IsValid)
      {
        // Add the booking to the database
        _context.Add(booking);
        await _context.SaveChangesAsync();

        // Redirect to the Confirmation action, passing the ID of the new booking
        return RedirectToAction("Confirmation", new { id = booking.FlightBookingId });
      }
      else
      {
        // Prepare the viewModel again for the form view if the model state is not valid
        var flight = await _context.Flights.FindAsync(booking.FlightId);
        if (flight == null)
        {
          // Handle the case where the flight no longer exists
          return NotFound();
        }

        var viewModel = new FlightBookingViewModel
        {
          Airline = flight.Airline,
          DepartureAirport = flight.DepartureAirport,
          ArrivalAirport = flight.ArrivalAirport,
          DepartureTime = flight.DepartureTime,
          ArrivalTime = flight.ArrivalTime,
          Price = flight.Price,
          // Populate CustomerName, CustomerEmail, and BookingDate from the submitted booking if needed
          CustomerName = booking.CustomerName,
          CustomerEmail = booking.CustomerEmail,
          BookingDate = booking.BookingDate
        };

        // Return to the "Book" view with the viewModel
        return View("Book", viewModel);
      }
    }



    public IActionResult Confirmation(int id)
    {
      var booking = _context.FlightBookings
          .Include(fb => fb.Flight)
          .FirstOrDefault(b => b.FlightBookingId == id);

      if (booking == null)
      {
        return NotFound();
      }

      // Return the confirmation view, passing in the booking as the model
      return View(booking);
    }


  }
}
