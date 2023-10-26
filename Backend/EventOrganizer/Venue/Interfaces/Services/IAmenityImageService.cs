namespace Venue.Interfaces.Services
{
    public interface IAmenityImageService<T> : IBaseService<T>
    {
        public Task<ICollection<T>> GetAllByID(T item);

    }
}
