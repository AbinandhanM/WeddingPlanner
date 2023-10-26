using Microsoft.EntityFrameworkCore;
using Venue.Context;
using Venue.Interfaces.Repository;
using Venue.Models;

namespace Venue.Repository
{
    public class RoomRepo : IRepo<int, Room>
    {
        private readonly VenueContext _context;

        public RoomRepo(VenueContext context)
        {
            _context = context;

        }
        public async Task<Room?> Add(Room item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Rooms == null)
                throw new Exception("Rooms collection is null");

            try
            {
                await _context.Rooms.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to add Room", ex);
            }
        }


        public async Task<Room?> Delete(Room item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Rooms == null)
                throw new Exception("Rooms collection is null");

            var existingRoom = await _context.Rooms.FindAsync(item.RoomID) ?? throw new InvalidOperationException($"Room with ID {item.RoomID} not found.");
            try
            {
                _context.Rooms.Remove(existingRoom);
                await _context.SaveChangesAsync();
                return existingRoom;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Failed to delete Room", ex);
            }
        }

        public async Task<Room?> Get(int key)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Rooms == null)
                throw new Exception("Rooms collection is null");

            try
            {
                var room = await _context.Rooms.FindAsync(key);
                return room;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Failed to get Room", ex);
            }
        }

        public async Task<List<Room>?> GetAll()
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Rooms == null)
                throw new Exception("Rooms collection is null");

            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                return rooms;
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to get all Rooms", ex);
            }

        }

        public async Task<Room?> Update(Room item)
        {
            if (_context == null)
                throw new InvalidOperationException("Context is null.");

            if (_context.Rooms == null)
                throw new Exception("Rooms collection is null");

            var existingRoom = await _context.Rooms.FindAsync(item.RoomID) ?? throw new InvalidOperationException($"Room with ID {item.RoomID} not found.");
            try
            {
                _context.Entry(existingRoom).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Failed to update Room", ex);
            }
        }
    }
}
