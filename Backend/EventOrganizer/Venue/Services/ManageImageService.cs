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
            if (image == null)
                throw new InvalidOperationException("Unable to Add image right now");

            return image;
        }

        public async Task<Image?> DeleteServices(Image item)
        {
            var delImage = await _repo.Delete(item);
            if (delImage == null)
                throw new InvalidOperationException("Unable to Delete Image right now");

            return delImage;
        }

        public async Task<ICollection<Image>> GetAllByID(int key)
        {
            var getAllImages= await _repo.GetAll();
            if (getAllImages == null)
                throw new InvalidOperationException("Unable to get images right now");

            var hallImages=getAllImages.Where(s=>s.HallID==key).ToList();
            if (hallImages == null)
                throw new InvalidOperationException("There is no Parking available");

            return hallImages;
        }
    }
}
