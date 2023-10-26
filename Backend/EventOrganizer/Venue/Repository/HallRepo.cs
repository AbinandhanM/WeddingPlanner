using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class HallRepo : IRepo<int, Hall>
    {
        private readonly VenueContext _context;

        public HallRepo(VenueContext context)
        {
            _context = context;
        }

        public async Task<Hall?> Add(Hall item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Halls == null)
            {
                throw new Exception("The Halls collection in the database context is null. Make sure it's properly configured.");
            }

            try
            {
                await _context.Halls.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Hall", ex);
            }
        }

        public async Task<Hall?> Delete(Hall item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Halls == null)
            {
                throw new Exception("The Halls collection in the database context is null. Make sure it's properly configured.");
            }

            var existingHall = await _context.Halls.FindAsync(item.HallID) ?? throw new InvalidOperationException($"Hall with ID {item.HallID} not found.");
            try
            {
                _context.Halls.Remove(existingHall);
                await _context.SaveChangesAsync();
                return existingHall;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Hall", ex);
            }
        }

        public async Task<Hall?> Get(int key)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Halls == null)
            {
                throw new Exception("The Halls collection in the database context is null. Make sure it's properly configured.");
            }

            try
            {
                var hall = await _context.Halls.FindAsync(key);
                return hall;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Hall", ex);
            }
        }

        public async Task<List<Hall>?> GetAll()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Halls == null)
            {
                throw new Exception("The Halls collection in the database context is null. Make sure it's properly configured.");
            }

            try
            {
                var halls = await _context.Halls.ToListAsync();
                return halls;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all Halls", ex);
            }
        }

        public async Task<Hall?> Update(Hall item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Halls == null)
            {
                throw new Exception("The Halls collection in the database context is null. Make sure it's properly configured.");
            }

            var existingHall = await _context.Halls.FindAsync(item.HallID) ?? throw new InvalidOperationException($"Hall with ID {item.HallID} not found.");
            try
            {
                _context.Entry(existingHall).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Hall", ex);
            }
        }
    }

}
