using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venue.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        public string? ImageURL { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        public string? Type { get; set; }

        [ForeignKey("Hall")]
        public int HallID { get; set; }
        [ForeignKey("Dining")]
        public int? DiningID { get; set; }
        [ForeignKey("Parking")]
        public int? ParkingID { get; set; }

        public Hall? Hall { get; set; }
        public Dining? Dining { get; set; }
        public Parking? Parking { get; set; }
    }
}
