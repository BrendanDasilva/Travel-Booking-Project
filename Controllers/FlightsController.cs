using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
  public class FlightsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public FlightsController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: Flights
    // Add sortOrder parameter
    public async Task<IActionResult> Index(string sortOrder)
    {
      // Pass current sort order to view via ViewData
      ViewData["CurrentSort"] = sortOrder;
      ViewData["AirlineSortParm"] = String.IsNullOrEmpty(sortOrder) ? "airline_desc" : "";
      ViewData["DestinationSortParm"] = sortOrder == "Destination" ? "destination_desc" : "Destination";
      ViewData["DepartureTimeSortParm"] = sortOrder == "DepartureTime" ? "departureTime_desc" : "DepartureTime";
      ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

      var flights = from f in _context.Flights
                    select f;

      switch (sortOrder)
      {
        case "airline_desc":
          flights = flights.OrderByDescending(f => f.Airline);
          break;
        case "Destination":
          flights = flights.OrderBy(f => f.Destination);
          break;
        case "destination_desc":
          flights = flights.OrderByDescending(f => f.Destination);
          break;
        case "DepartureTime":
          flights = flights.OrderBy(f => f.DepartureTime);
          break;
        case "departureTime_desc":
          flights = flights.OrderByDescending(f => f.DepartureTime);
          break;
        case "Price":
          flights = flights.OrderBy(f => f.Price);
          break;
        case "price_desc":
          flights = flights.OrderByDescending(f => f.Price);
          break;
        default:
          flights = flights.OrderBy(f => f.Airline);
          break;
      }

      return View(await flights.AsNoTracking().ToListAsync());
    }
  }
}
