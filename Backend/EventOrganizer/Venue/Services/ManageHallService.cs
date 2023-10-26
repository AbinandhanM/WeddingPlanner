using Venue.Interfaces;
using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;

namespace Venue.Services
{
    public class ManageHallService : IHallService<Hall, int>
    {
        private readonly IRepo<int, Hall> _hallRepo;

        public ManageHallService(IRepo<int ,Hall> hallRepo) 
        {
            _hallRepo = hallRepo;
        }

        public async Task<Hall?> AddServices(Hall item)
        {
            var hall = await _hallRepo.Add(item);
            return hall ?? throw new InvalidOperationException("Unable to add hall right now");
        }


        public async Task<Hall?> DeleteServices(Hall item)
        {
            var delHall = await _hallRepo.Delete(item);
            return delHall == null ? throw new InvalidOperationException("Unable to delete hall right now") : item;
        }

        public async Task<ICollection<Hall>> GetAllByLocations(int key)
        {
             var Halls = await _hallRepo.GetAll();
            return Halls == null
                ? throw new InvalidOperationException("Unable to get hall right now")
                : (ICollection<Hall>)Halls.Where(s => s.City_ID == key).ToList();
        }

        public async Task<Hall> GetByID(int key)
        {
            var hall = await _hallRepo.Get(key);
            return hall ?? throw new InvalidOperationException("Unable to delete hall right now");
        }


        public async Task<Hall?> UpdateServices(Hall item)
        {
            var existingHall = await _hallRepo.Get(item.HallID);

            if (existingHall != null)
            {
                existingHall.HallName = item.HallName;
                existingHall.Type = item.Type;
                existingHall.Parking = item.Parking;
                existingHall.StageSpace = item.StageSpace;
                existingHall.Capacity = item.Capacity;
                existingHall.City_ID = item.City_ID;
                existingHall.Category_ID = item.Category_ID;
                existingHall.Description = item.Description;
                existingHall.Address = item.Address;
                existingHall.RentalPrice = item.RentalPrice;

                await _hallRepo.Update(existingHall);
                return existingHall;
            }
            throw new InvalidOperationException("Unable to update hall right now");
        }


    }
}
