using Venue.Interfaces.Repository;
using Venue.Interfaces.Services;
using Venue.Models;

namespace Venue.Services
{
    public class ManageCategoryService : ICategoryService<Category>
    {
        private readonly IRepo<int, Category> _repo;

        public ManageCategoryService(IRepo<int,Category> repo)
        {
            _repo = repo;
        }
        public async Task<Category?> AddServices(Category item)
        {
            var category = await _repo.Add(item);
            if (category == null)
                throw new InvalidOperationException("Unable to Add Category right now");

            return category;
        }

        public async Task<Category?> DeleteServices(Category item)
        {
            var category = await _repo.Add(item);
            if (category == null)
                throw new InvalidOperationException("Unable to delete category right now");

            return category;
        }

        public async Task<ICollection<Category>> GetAllCategory()
        {
            var categories = await _repo.GetAll();
            if (categories == null)
                throw new InvalidOperationException("Unable to get Categories");
            return categories;
        }
    }
}
