using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;
using Venue.Repository;

namespace Venue.Services
{
    public class ManageAmenityService : IAmenityImageService<Amenity, int>
    {
        private readonly IRepo<int, Amenity> _amenityRepo;

        public ManageAmenityService(IRepo<int, Amenity> amenityRepo)
        {
            _amenityRepo = amenityRepo;
        }
        public async Task<Amenity> AddServices(Amenity item)
        {
            try
            {
                await _amenityRepo.Add(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception(" Amenity Services can't be added");
            }
        }

        public async Task<Amenity> DeleteServices(Amenity item)
        {
            try
            {
                await _amenityRepo.Delete(item);
                return item;
            }
            catch (Exception)
            {
                throw new Exception("Amenity Services can't be deleted");
            }
        }

        public async Task<ICollection<Amenity>> GetAllByID(int key)
        {
            try
            {
                var allAmenities = await _amenityRepo.GetAll();
                if (allAmenities == null)
                {
                    return new List<Amenity>();
                }
                return allAmenities.Where(s => s.HallID ==key).ToList();

            }
            catch (Exception)
            {
                throw new Exception("Error in Get All By Locations ");
            }
        }
    }
}
