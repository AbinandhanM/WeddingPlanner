using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;
using Venue.Repository;

namespace Venue.Services
{
    public class ManageRoomService : IRoomService<Room>
    {
        private readonly IRepo<int, Room> _roomRepo;

        public ManageRoomService(IRepo<int, Room> roomRepo)
        {
            _roomRepo = roomRepo;
        }
        public async Task<Room> AddServices(Room item)
        {
            try
            {
                await _roomRepo.Add(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception(" Room Services can't be added");
            }
        }

        public async Task<Room> DeleteServices(Room item)
        {
            try
            {
                await _roomRepo.Delete(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Room Services can't be deleted");
            }
        }

        public Task<ICollection<Room>> GetAllByIDService(Room item)
        {
            throw new NotImplementedException();
        }

        public Task<Room> UpdateServices(Room item)
        {
            throw new NotImplementedException();
        }
    }
}
