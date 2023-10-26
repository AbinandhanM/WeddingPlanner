using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;

namespace Venue.Services
{
    public class ManageDiningService : IGetServices<Dining, int>
    {
        private readonly IRepo<int, Dining> _repo;

        public ManageDiningService(IRepo<int,Dining> repo)
        {
            _repo = repo;
        }
        public async Task<Dining?> AddServices(Dining item)
        {
            var dining = await _repo.Add(item);
            if (dining == null)
                throw new InvalidOperationException("Unable to Add Dining right now");

            return dining;
        }

        public async Task<Dining?> DeleteServices(Dining item)
        {
            var dining = await _repo.Delete(item);
            if (dining == null)
                throw new InvalidOperationException("Unable to Delete Dining right now");

            return dining;
        }

        public async Task<Dining> GetByID(int key)
        {
            var dining = await _repo.Get(key);
            if (dining == null)
                throw new InvalidOperationException("Unable to Get Dining right now");

            return dining;
        }

        public async Task<Dining?> UpdateServices(Dining item)
        {
            var getDining = await _repo.Get(item.DiningID);
            if (getDining == null)
                throw new InvalidOperationException("Unable to find the dining right now");

            getDining.Capacity = item.Capacity;
            getDining.SpaceSqft = item.SpaceSqft;
            var updatedDining= await _repo.Update(getDining);
            if (updatedDining == null)
                throw new InvalidOperationException("Unable to Update Dining right now");

            return updatedDining;
        }
    }
}
