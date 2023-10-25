using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venue.Models
{
    public class Hall
    {
        [Key]
        public int HallID { get; set; }

        [Required(ErrorMessage = "Hall Name is required.")]
        public string? HallName { get; set; }

        [Required(ErrorMessage = "AC/Non-AC is required.")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Parking/No Parking is required.")]
        public string? Parking { get; set; }

        [Required(ErrorMessage = "Stage Space is required.")]
        public string? StageSpace { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "CityID is required.")]

        public int City_ID { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Category is required.")]
        public int Category_ID { get; set; }

        public Category? Category { get; set; }


        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Rental Price is required.")]
        public decimal RentalPrice { get; set; }

        // Navigation properties
        public List<Amenity>? Amenities { get; set; }
        public List<Image>? Images { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
