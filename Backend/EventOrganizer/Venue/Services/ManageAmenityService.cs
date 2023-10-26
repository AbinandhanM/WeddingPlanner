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
            
            var amenity = await _amenityRepo.Add(item);
            if (amenity == null)
                throw new InvalidOperationException("Unable to add amenity right now");
            return amenity;
           
        }

        public async Task<Amenity> DeleteServices(Amenity item)
        {
            var delAmenity=await _amenityRepo.Delete(item);
            if (delAmenity == null)
                throw new InvalidOperationException("Unable to delete amenity");
            return delAmenity;
            
        }

        public async Task<ICollection<Amenity>> GetAllByID(int key)
        {
            var allAmenities = await _amenityRepo.GetAll();
            if (allAmenities == null)
                throw new InvalidOperationException("Unable to get amenities");

            return allAmenities.Where(s => s.HallID == key).ToList();
        }
    }
}
