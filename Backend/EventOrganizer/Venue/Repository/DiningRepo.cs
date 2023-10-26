using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class DiningRepo : IRepo<int, Dining>
    {
        private readonly VenueContext _context;

        public DiningRepo(VenueContext context)
        {
            _context = context;
        }

        public async Task<Dining?> Add(Dining item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Dinings == null)
                throw new Exception("The Dining collection in the database context is null. Make sure it's properly configured.");

            try
            {
                await _context.Dinings.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Dining", ex);
            }
        }

        public async Task<Dining?> Delete(Dining item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Dinings == null)
                throw new Exception("The Dining collection in the database context is null. Make sure it's properly configured.");

            var existingDining = await _context.Dinings.FindAsync(item.DiningID) ?? throw new InvalidOperationException($"Dining with ID {item.DiningID} not found.");
            try
            {
                _context.Dinings.Remove(existingDining);
                await _context.SaveChangesAsync();
                return existingDining;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Dining", ex);
            }
        }

        public async Task<Dining?> Get(int key)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Dinings == null)
                throw new Exception("The Dining collection in the database context is null. Make sure it's properly configured.");

            try
            {
                var dining = await _context.Dinings.FindAsync(key);
                return dining;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Dining", ex);
            }
        }

        public async Task<List<Dining>?> GetAll()
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Dinings == null)
                throw new Exception("The Dining collection in the database context is null. Make sure it's properly configured.");

            try
            {
                var dinings = await _context.Dinings.ToListAsync();
                return dinings;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all Dinings", ex);
            }
        }

        public async Task<Dining?> Update(Dining item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Dinings == null)
                throw new Exception("The Dining collection in the database context is null. Make sure it's properly configured.");
            

            var existingDining = await _context.Dinings.FindAsync(item.DiningID) ?? throw new InvalidOperationException($"Dining with ID {item.DiningID} not found.");
            try
            {
                _context.Entry(existingDining).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Dining", ex);
            }
        }
    }

}
