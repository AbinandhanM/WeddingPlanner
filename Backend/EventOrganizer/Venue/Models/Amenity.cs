using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venue.Models
{
    public class Amenity
    {
        [Key]
        public int AmenityID { get; set; }

        [Required(ErrorMessage = "Amenity Name is required.")]
        public string? AmenityName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }


        [ForeignKey("Hall")]
        public int HallID { get; set; }

        public Hall? Hall { get; set; }
    }
}
