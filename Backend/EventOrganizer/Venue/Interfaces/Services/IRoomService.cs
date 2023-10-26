namespace Venue.Interfaces.Services
{
    public interface IRoomService<T,K> : IUpdateSerivce<T>
    {
        public Task<ICollection<T>> GetAllByIDService(K key);

    }
}
