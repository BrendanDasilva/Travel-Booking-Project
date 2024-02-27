using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
  private readonly ApplicationDbContext _context;

  public AdminController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult AdminIndex()
  {
    return View();
  }

  // GET: Admin/CreateFlight
  public IActionResult CreateFlight()
  {
    return View();
  }

  // POST: Admin/CreateFlight
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> CreateFlight([Bind("Airline,Destination,DepartureAirport,ArrivalAirport,DepartureTime,ArrivalTime,Price")] Flight flight)
  {
    if (ModelState.IsValid)
    {
      _context.Add(flight);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(ListFlights)); // Redirecting to ListFlights action
    }
    return View(flight);
  }

  // GET: Admin/CreateCar
  public IActionResult CreateCar()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> CreateCar([Bind("Brand,Model,Year,PricePerDay,IsAvailable")] Cars car)
  {
    if (ModelState.IsValid)
    {
      _context.Add(car);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(ListCars)); // Redirecting to ListCars action
    }
    else
    {
      // Collecting all errors
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
      ViewBag.Errors = errors; // Passing errors to the view via ViewBag
      return View(car);
    }
  }

  public IActionResult ListFlights()
  {
    var flights = _context.Flights.ToList();
    return View(flights);
  }

  public IActionResult ListCars()
  {
    var cars = _context.Cars.ToList();
    return View(cars);
  }

  public IActionResult ListHotels()
  {
    var hotels = _context.Hotels.ToList();
    return View(hotels);
  }

  // GET: Admin/EditCar/5
  public async Task<IActionResult> EditCar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var car = await _context.Cars.FindAsync(id);
    if (car == null)
    {
      return NotFound();
    }
    return View(car);
  }

  // POST: Admin/EditCar/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> EditCar(int id, [Bind("CarId,Brand,Model,Year,PricePerDay,IsAvailable")] Cars car)
  {
    if (id != car.CarId)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(car);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CarExists(car.CarId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction(nameof(ListCars));
    }
    return View(car);
  }

  private bool CarExists(int id)
  {
    return _context.Cars.Any(e => e.CarId == id);
  }

  // GET: Admin/DeleteCar/5
  public async Task<IActionResult> DeleteCar(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var car = await _context.Cars
        .FirstOrDefaultAsync(m => m.CarId == id);
    if (car == null)
    {
      return NotFound();
    }

    return View(car);
  }

  // POST: Admin/DeleteCarConfirmed/5
  [HttpPost, ActionName("DeleteCarConfirmed")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteCarConfirmed(int id)
  {
    var car = await _context.Cars.FindAsync(id);
    if (car != null) // Check if the car is not null
    {
      _context.Cars.Remove(car);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(ListCars));
  }



  // GET: Admin/EditFlight/5
  public async Task<IActionResult> EditFlight(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var flight = await _context.Flights.FindAsync(id);
    if (flight == null)
    {
      return NotFound();
    }
    return View(flight);
  }

  // POST: Admin/EditFlight/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> EditFlight(int id, [Bind("FlightId,Airline,Destination,DepartureAirport,ArrivalAirport,DepartureTime,ArrivalTime,Price")] Flight flight)
  {
    if (id != flight.FlightId)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(flight);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FlightExists(flight.FlightId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction(nameof(ListFlights));
    }
    return View(flight);
  }

  private bool FlightExists(int id)
  {
    return _context.Flights.Any(e => e.FlightId == id);
  }

  // GET: Admin/DeleteFlight/5
  public async Task<IActionResult> DeleteFlight(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var flight = await _context.Flights
        .FirstOrDefaultAsync(m => m.FlightId == id);
    if (flight == null)
    {
      return NotFound();
    }

    return View(flight);
  }

  // POST: Admin/DeleteFlightConfirmed/5
  [HttpPost, ActionName("DeleteFlightConfirmed")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteFlightConfirmed(int id)
  {
    var flight = await _context.Flights.FindAsync(id);
    if (flight != null) // Check if the flight is not null
    {
      _context.Flights.Remove(flight);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(ListFlights));
  }

  // HOTEL ACTIONS
  // GET: Admin/CreateHotel
  public IActionResult CreateHotel()
  {
    return View();
  }

  // POST: Admin/CreateHotel
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> CreateHotel([Bind("Name,Location,PricePerNight,Amenities,ServiceType")] Hotel hotel)
  {
    if (ModelState.IsValid)
    {
      _context.Hotels.Add(hotel);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(ListHotels));
    }
    return View(hotel);
  }

  // GET: Admin/EditHotel/5
  public async Task<IActionResult> EditHotel(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var hotel = await _context.Hotels.FindAsync(id);
    if (hotel == null)
    {
      return NotFound();
    }
    return View(hotel);
  }

  // POST: Admin/EditHotel/5
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> EditHotel(int id, [Bind("HotelId,Name,Location,PricePerNight,Amenities,ServiceType")] Hotel hotel)
  {
    if (id != hotel.HotelId)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(hotel);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!HotelExists(hotel.HotelId))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction(nameof(ListHotels));
    }
    return View(hotel);
  }

  private bool HotelExists(int id)
  {
    return _context.Hotels.Any(e => e.HotelId == id);
  }


  // GET: Admin/DeleteHotel/5
  public async Task<IActionResult> DeleteHotel(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }

    var hotel = await _context.Hotels
        .FirstOrDefaultAsync(m => m.HotelId == id);
    if (hotel == null)
    {
      return NotFound();
    }

    return View(hotel);
  }

  // POST: Admin/DeleteHotelConfirmed/5
  [HttpPost, ActionName("DeleteHotelConfirmed")]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> DeleteHotelConfirmed(int id)
  {
    var hotel = await _context.Hotels.FindAsync(id);
    if (hotel != null)
    {
      _context.Hotels.Remove(hotel);
      await _context.SaveChangesAsync();
    }
    return RedirectToAction(nameof(ListHotels));
  }

}
