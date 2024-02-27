using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    [Table("CarRentals")]
    public class CarRental
    {
        [Key]
        public int RentalId { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmail { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        // Foreign key for the Car
        [ForeignKey("Car")]
        public int CarId { get; set; }

        // Navigation property to the Car
        public virtual Cars Car { get; set; }

        public bool IsCanceled { get; set; }  
    }
}
