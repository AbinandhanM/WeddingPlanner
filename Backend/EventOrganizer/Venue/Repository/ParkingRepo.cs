using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces;
using Venue.Models;

namespace Venue.Repository
{
    public class ParkingRepo : IRepo<int, Parking>
    {
        private readonly VenueContext _context;

        public ParkingRepo(VenueContext context)
        {
            _context = context;
        }

        public async Task<Parking?> Add(Parking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }


            if (_context.Parkings == null)
            {
                throw new Exception("The Parking collection in the database context is null. Make sure it's properly configured.");
            }

            try
            {
                await _context.Parkings.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add Parking", ex);
            }
        }

        public async Task<Parking?> Delete(Parking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }


            if (_context.Parkings == null)
            {
                throw new Exception("The Parking collection in the database context is null. Make sure it's properly configured.");
            }

            var existingParking = await _context.Parkings.FindAsync(item.ParkingID) ?? throw new InvalidOperationException($"Parking with ID {item.ParkingID} not found.");
            try
            {
                _context.Parkings.Remove(existingParking);
                await _context.SaveChangesAsync();
                return existingParking;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete Parking", ex);
            }
        }

        public async Task<Parking?> Get(int key)
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }


            if (_context.Parkings == null)
            {
                throw new Exception("The Parking collection in the database context is null. Make sure it's properly configured.");
            }

            try
            {
                var parking = await _context.Parkings.FindAsync(key);
                return parking;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get Parking", ex);
            }
        }

        public async Task<List<Parking>?> GetAll()
        {
            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }

            if (_context.Parkings == null)
            {
                throw new Exception("The Parking collection in the database context is null. Make sure it's properly configured.");
            }


            try
            {
                var parkings = await _context.Parkings.ToListAsync();
                return parkings;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all Parking", ex);
            }
        }

        public async Task<Parking?> Update(Parking item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            if (_context == null)
            {
                throw new InvalidOperationException("Context is null.");
            }


            if (_context.Parkings == null)
            {
                throw new Exception("The Parking collection in the database context is null. Make sure it's properly configured.");
            }

            var existingParking = await _context.Parkings.FindAsync(item.ParkingID) ?? throw new InvalidOperationException($"Parking with ID {item.ParkingID} not found.");
            try
            {
                _context.Entry(existingParking).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update Parking", ex);
            }
        }
    }

}
