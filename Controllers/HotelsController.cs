using Assignment1.Data;
using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignment1.Controllers
{
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

    public IActionResult Index(string sortOrder)
    {
      ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

      var hotels = from h in _context.Hotels
                   select h;

      switch (sortOrder)
      {
        case "name_desc":
          hotels = hotels.OrderByDescending(h => h.Name);
          break;
        case "Price":
          hotels = hotels.OrderBy(h => h.PricePerNight);
          break;
        case "price_desc":
          hotels = hotels.OrderByDescending(h => h.PricePerNight);
          break;
        default:
          hotels = hotels.OrderBy(h => h.Name);
          break;
      }

      return View(hotels.ToList());
    }

    public IActionResult Create()
        {
            return View();
        }

        //VIEW DETAILS OF EACH HOTEL
        public IActionResult Details()
        {
            return View();
        }



    }
}

