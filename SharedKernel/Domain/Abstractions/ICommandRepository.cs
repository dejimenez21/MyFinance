using SharedKernel.Domain.Primitives;

namespace SharedKernel.Domain.Abstractions;

public interface ICommandRepository<T> where T : Entity
{
    void Insert(T entity);
    void Update(T entity);
    void DeleteById(Guid id);

    Task<int> SaveChangesAsync();
}
