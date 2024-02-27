using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Price Per Day is required")]
        public double PricePerDay { get; set; }

        public bool IsAvailable { get; set; }
    }
}
