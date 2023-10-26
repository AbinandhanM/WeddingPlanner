namespace Venue.Interfaces.Services
{
    public interface IAmenityImageService<T, K> : IBaseService<T>
    {
        public Task<ICollection<T>> GetAllByID(K key);

    }
}
