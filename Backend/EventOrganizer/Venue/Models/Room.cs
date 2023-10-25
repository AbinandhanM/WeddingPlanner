using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venue.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Type (AC/NON) is required.")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Number of Rooms is required.")]
        public int NumberOfRooms { get; set; }

        [ForeignKey("Hall")]
        public int HallID { get; set; }

        public Hall? Hall { get; set; }
    }
}
