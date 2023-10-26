namespace Venue.Interfaces.Services
{
    public interface IHallService<T, K> : IGetServices<T, K>
    {
        public Task<ICollection<T>> GetAllByLocations(K key);

    }
}
