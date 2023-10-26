namespace Venue.Interfaces.Services
{
    public interface IUpdateSerivce<T> : IBaseService<T>
    {
        public Task<T?> UpdateServices(T item);


    }
}
