namespace Venue.Interfaces.Services
{
    public interface IRoomService<T> : IUpdateSerivce<T>
    {
        public Task<ICollection<T>> GetAllByIDService(T item);

    }
}
