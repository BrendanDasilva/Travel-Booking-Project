using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
  public class HomeController : Controller
  {
    private readonly ApplicationDbContext _context; 

    public HomeController(ApplicationDbContext context)
    {
      _context = context;
    }
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      return View();
    }

    public async Task<IActionResult> Search(string destination, DateTime? departureDate, DateTime? returnDate)
    {
      // Initialize an IQueryable<Flight> query
      IQueryable<Flight> query = _context.Flights;

      // Filter by destination if provided
      if (!string.IsNullOrWhiteSpace(destination))
      {
        query = query.Where(f => f.Destination.Contains(destination));
      }

      // Filter by departure date if provided
      if (departureDate.HasValue)
      {
        query = query.Where(f => f.DepartureTime.Date >= departureDate.Value.Date);
      }

      // Filter by return date if provided
      if (returnDate.HasValue)
      {
        query = query.Where(f => f.ArrivalTime.Date <= returnDate.Value.Date);
      }

      // Execute the query and get the results
      var results = await query.ToListAsync();

      // Pass the results to the view
      return View("SearchResults", results);
    }
  }
}
