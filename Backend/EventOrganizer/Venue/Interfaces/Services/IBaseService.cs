using Venue.Models;

namespace Venue.Interfaces.Services
{
    public interface IBaseService<T>
    {
        public Task<T?> AddServices(T item);

        public Task<T?> DeleteServices(T item);

    }

}
