using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class AmenityRepo : IRepo<int, Amenity>
    {
        private readonly VenueContext _context;

        public AmenityRepo(VenueContext context)
        {
            _context = context;

        }

        public async Task<Amenity?> Add(Amenity item)
        {
            if (_context == null)
            {
                throw new Exception("Context is null");
            }

            if (_context.Amenities == null)
            {
                throw new Exception("Amenities collection is null");
            }

            try
            {
                await _context.Amenities.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Amenity", ex);
            }
        }




        public async Task<Amenity?> Delete(Amenity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item is null.");

            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Amenities == null)
                throw new Exception("Amenities collection is null");

            var existingAmenity = await _context.Amenities.FindAsync(item.AmenityID) ?? throw new InvalidOperationException($"Amenity with ID {item.AmenityID} not found.");
            try
            {
                _context.Amenities.Remove(existingAmenity);
                await _context.SaveChangesAsync();
                return existingAmenity;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Amenity", ex);
            }
        }


        public async Task<Amenity?> Get(int key)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }
            if (_context.Amenities == null)
            {
                throw new Exception("Amenities collection is null");
            }
            try
            {
                var amenity = await _context.Amenities.FindAsync(key);
                return amenity;
            }
            catch (Exception ex)
            {
                 throw new Exception("Failed to get Amenity", ex);
            }
        }


        public async Task<List<Amenity>?> GetAll()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }
            if (_context.Amenities == null)
            {
                throw new Exception("Amenities collection is null");
            }

            try
            {
                var amenities = await _context.Amenities.ToListAsync();
                return amenities;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to get all Amenities", ex);
            }
        }


        public async Task<Amenity?> Update(Amenity item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }
            if (_context.Amenities == null)
            {
                throw new Exception("Amenities collection is null");
            }

            var existingAmenity = await _context.Amenities.FindAsync(item.AmenityID) ?? throw new InvalidOperationException($"Amenity with ID {item.AmenityID} not found.");
            try
            {
                _context.Entry(existingAmenity).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to update Amenity", ex);
            }
        }

    }
}
