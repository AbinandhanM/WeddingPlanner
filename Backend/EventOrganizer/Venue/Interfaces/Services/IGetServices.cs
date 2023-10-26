namespace Venue.Interfaces.Services
{
    public interface IGetServices<T, K> : IUpdateSerivce<T>
    {
        public Task<T> GetByID(K key);


    }
}
