using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCar([Bind("Brand,Model,Year,PricePerDay,IsAvailable")] Cars car)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); // Redirect to the car listing page
            }
            return View(car); // If model state is not valid, return the same view with validation errors
        }

        public List<Cars> GetAvailableCars()
        {
            return _context.Cars.Where(car => car.IsAvailable).ToList();
        }

        public void MarkCarAsUnavailable(int carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                car.IsAvailable = false;
                _context.SaveChanges();
            }
        }

        public void MarkCarAsAvailable(int carId)
        {
            var car = _context.Cars.FirstOrDefault(c => c.CarId == carId);
            if (car != null)
            {
                car.IsAvailable = true;
                _context.SaveChanges();
            }
        }
    }
}
