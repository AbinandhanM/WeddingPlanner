using System.ComponentModel.DataAnnotations;

namespace Venue.Models
{
    public class Parking
    {
        [Key]
        public int ParkingID { get; set; }

        [Required(ErrorMessage = "Car Capacity is required.")]
        public int FourWheelerCapacity { get; set; }

        [Required(ErrorMessage = "Bike Capacity is required.")]
        public int TwoWheelerCapacity { get; set; }
    }
}
