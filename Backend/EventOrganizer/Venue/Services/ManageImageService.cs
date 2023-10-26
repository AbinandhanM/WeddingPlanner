using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;

namespace Venue.Services
{
    public class ManageImageService : IAmenityImageService<Image, int>
    {
        private readonly IRepo<int, Image> _repo;

        public ManageImageService(IRepo<int,Image> repo)
        {
            _repo = repo;
        }
        public async Task<Image?> AddServices(Image item)
        {
            var image = await _repo.Add(item);
            return image ?? throw new InvalidOperationException("Unable to Add image right now");
        }

        public async Task<Image?> DeleteServices(Image item)
        {
            var delImage = await _repo.Delete(item);
            return delImage ?? throw new InvalidOperationException("Unable to Delete Image right now");
        }

        public async Task<ICollection<Image>?> GetAllByID(int key)
        {
            var getAllImages = await _repo.GetAll() ?? throw new InvalidOperationException("Unable to get images right now");
            var hallImages = getAllImages.Where(s => s.HallID == key).ToList();
            return hallImages.Count == 0 ? throw new InvalidOperationException("There are no Parking images available") : (ICollection<Image>)hallImages;
        }

    }
}
