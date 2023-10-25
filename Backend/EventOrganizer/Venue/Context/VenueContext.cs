using Microsoft.EntityFrameworkCore;
using Venue.Models;

namespace Venue.Context
{
    public class VenueContext :DbContext
    {
        public VenueContext(DbContextOptions<VenueContext> options) :base(options) { }

        public DbSet<Amenity>? Amenities { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Dining>? Dinings { get; set; }
        public DbSet<Hall>? Halls { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Parking>? Parkings { get; set; }
        public DbSet<Room>? Rooms { get; set; }



    }
}
