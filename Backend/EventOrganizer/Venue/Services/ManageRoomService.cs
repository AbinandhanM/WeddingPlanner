using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;
using Venue.Repository;

namespace Venue.Services
{
    public class ManageRoomService : IRoomService<Room,int>
    {
        private readonly IRepo<int, Room> _roomRepo;

        public ManageRoomService(IRepo<int, Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }
        public async Task<Room?> AddServices(Room item)
        {
            var room = await _roomRepo.Add(item);
            return room == null ? throw new InvalidOperationException("Unable to add room right now") : item;
        }

        public async Task<Room?> DeleteServices(Room item)
        {
           
            var delRoom =await _roomRepo.Delete(item);
            return delRoom == null ? throw new InvalidOperationException("Unable to delete room right now") : item;
        }

        public async Task<ICollection<Room>> GetAllByIDService(int id)
        {

            var rooms = await _roomRepo.GetAll();
            return rooms == null ? throw new InvalidOperationException("Rooms Are not there") : (ICollection<Room>)rooms.Where(s => s.HallID == id).ToList();
        }

        public async Task<Room?> UpdateServices(Room item)
        {
            var getRoom= await _roomRepo.Get(item.RoomID) ?? throw new InvalidOperationException("Rooms Are not there");
            getRoom.NumberOfRooms = item.NumberOfRooms;
            var updatedRoom = await _roomRepo.Update(getRoom);
                
            if (updatedRoom != null)
                    return updatedRoom;
            throw new DbUpdateException("Uanble to update the Room Database right now");

          
        }
    }
}
