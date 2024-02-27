using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Controllers
{
    public class CarRentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewData["ModelSortParm"] = sortOrder == "Model" ? "model_desc" : "Model";
            ViewData["YearSortParm"] = sortOrder == "Year" ? "year_desc" : "Year";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["AvailableSortParm"] = sortOrder == "Available" ? "available_desc" : "Available";

            var cars = from c in _context.Cars
                       where c.IsAvailable
                       select c;

            switch (sortOrder)
            {
                case "brand_desc":
                    cars = cars.OrderByDescending(c => c.Brand);
                    break;
                case "Model":
                    cars = cars.OrderBy(c => c.Model);
                    break;
                case "model_desc":
                    cars = cars.OrderByDescending(c => c.Model);
                    break;
                case "Year":
                    cars = cars.OrderBy(c => c.Year);
                    break;
                case "year_desc":
                    cars = cars.OrderByDescending(c => c.Year);
                    break;
                case "Price":
                    cars = cars.OrderBy(c => c.PricePerDay);
                    break;
                case "price_desc":
                    cars = cars.OrderByDescending(c => c.PricePerDay);
                    break;
                case "Available":
                    cars = cars.OrderBy(c => c.IsAvailable);
                    break;
                case "available_desc":
                    cars = cars.OrderByDescending(c => c.IsAvailable);
                    break;
                default:
                    cars = cars.OrderBy(c => c.Brand);
                    break;
            }

            return View(await cars.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        public IActionResult Book(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBooking(int carId, string customerName, string customerEmail, DateTime pickupDate, DateTime returnDate)
        {
            if (pickupDate >= returnDate)
            {
                ModelState.AddModelError("pickupDate", "Pickup date must be before return date.");
            }

            if (!ModelState.IsValid)
            {
                var car = _context.Cars.Find(carId);
                return View("Book", car);
            }

            try
            {
                var carRental = new CarRental
                {
                    CustomerName = customerName,
                    CustomerEmail = customerEmail,
                    PickupDate = pickupDate,
                    ReturnDate = returnDate,
                    CarId = carId
                };

                _context.CarRentals.Add(carRental);


                var car = _context.Cars.Find(carId);
                car.IsAvailable = false;
                _context.SaveChanges();

                return RedirectToAction("Confirmation", new { id = carRental.RentalId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the booking to the database. Please try again.");
            }


            var carModel = _context.Cars.Find(carId);
            return View("Book", carModel);
        }

        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            var carRental = _context.CarRentals
                .Include(cr => cr.Car)
                .FirstOrDefault(cr => cr.RentalId == id);

            if (carRental == null)
            {
                return NotFound();
            }

            return View(carRental);
        }

        public IActionResult CurrentRentals()
        {
            var currentRentals = _context.CarRentals
                .Include(cr => cr.Car)
                .ToList();

            return View(currentRentals);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelRental(int id)
        {
            var rental = _context.CarRentals.Include(cr => cr.Car).FirstOrDefault(cr => cr.RentalId == id);
            if (rental == null)
            {
                return NotFound();
            }

            // Mark the associated car as available
            rental.Car.IsAvailable = true;

            _context.CarRentals.Remove(rental);
            _context.SaveChanges();

            return RedirectToAction(nameof(CurrentRentals));
        }



    }
}
