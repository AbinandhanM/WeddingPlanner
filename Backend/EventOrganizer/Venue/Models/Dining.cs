using System.ComponentModel.DataAnnotations;

namespace Venue.Models
{
    public class Dining
    {
        [Key]
        public int DiningID { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Space (sqft) is required.")]
        public int SpaceSqft { get; set; }
    }
}
