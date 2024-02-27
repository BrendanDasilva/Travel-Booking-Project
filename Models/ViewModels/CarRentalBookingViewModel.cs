using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class CarRentalBookingViewModel
    {
        // Car Details
        [Key]
        public int CarId { get; set; }

        public string CarYear { get; set; }

        [Required]
        public string CarBrand { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Price Per Day")]
        public double CarPricePerDay { get; set; }

        // Rental Details
        [Required(ErrorMessage = "Customer name is required.")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Pickup date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; }

        [Required(ErrorMessage = "Return date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
    }
}

