using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();

    }
}
