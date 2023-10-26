using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;

namespace Venue.Services
{
    public class ManageParkingService : IGetServices<Parking, int>
    {
        private readonly IRepo<int, Parking> _repo;

        public ManageParkingService(IRepo<int, Parking> repo)
        {
            _repo=repo;
        }
        public async Task<Parking?> AddServices(Parking item)
        {
            var parking=await _repo.Add(item);
            return parking ?? throw new InvalidOperationException("Unable to Add Parking right now");
        }

        public async Task<Parking?> DeleteServices(Parking item)
        {
            var delParking=await _repo.Delete(item);
            return delParking ?? throw new InvalidOperationException("Unable to Delete Parking right now");
        }

        public async Task<Parking> GetByID(int key)
        {
            var getParking=await _repo.Get(key);
            return getParking ?? throw new InvalidOperationException("There is no Parking available");
        }

        public async Task<Parking?> UpdateServices(Parking item)
        {
            var updateParking = await _repo.Update(item);
            return updateParking ?? throw new InvalidOperationException("Unable to update parking right now");
        }
    }
}
