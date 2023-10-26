namespace Venue.Interfaces.Services
{
    public interface ICategoryService<T> : IBaseService<T>
    {
        public Task<ICollection<T>> GetAllCategory();
    }
}
