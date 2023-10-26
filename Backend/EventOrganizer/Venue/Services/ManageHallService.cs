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

        public async Task<Hall> AddServices(Hall item)
        {
            try
            {
                await _hallRepo.Add(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception(" Hall Services can't be added");
            }

        }

        public async Task<Hall> DeleteServices(Hall item)
        {
            try
            {
                await _hallRepo.Delete(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Hall Services can't be deleted");
            }
        }

        public async Task<ICollection<Hall>> GetAllByLocations(int key)
        {
            try
            {
                var Halls = await _hallRepo.GetAll();
                if (Halls == null)
                {
                    return new List<Hall>(); 
                }
                return Halls.Where(s => s.City_ID == key).ToList();

            }
            catch (Exception)
            {
                throw new Exception("Error in Get All By Locations ");
            }
          
        }

        public async Task<Hall> GetByID(int key)
        {
            try
            {
                var hall = await _hallRepo.Get(key);
                if (hall != null)
                {
                    return hall;
                }
                throw new Exception("Hall not found"); 
            }
            catch (Exception )
            {
                  throw new Exception("Error in GetById");
            }
        }


        public async Task<Hall> UpdateServices(Hall item)
        {
            try
            {
                // Fetch the existing Hall record from the repository
                var existingHall = await _hallRepo.Get(item.HallID);

                if (existingHall != null)
                {
                    // Update the properties of the existing Hall with values from the provided 'item'
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
                else
                {
                    throw new Exception("Hall not found"); 
                }
            }
            catch (Exception)
            {
               
                throw new Exception("Error in UpdateServices");
            }
        }

    }
}
