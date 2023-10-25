using System.ComponentModel.DataAnnotations;

namespace Venue.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string? CategoryName { get; set; }
   
    }
}
