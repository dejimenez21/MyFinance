using SharedKernel.Domain.Primitives;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetByIdsAsync(Guid[] ids);

    }
}
