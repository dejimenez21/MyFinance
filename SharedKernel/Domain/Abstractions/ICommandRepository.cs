using SharedKernel.Domain.Primitives;

namespace SharedKernel.Domain.Abstractions;

public interface ICommandRepository<T> : IReadRepository<T> 
    where T : AggregateRoot
{
    void Insert(T entity);
    void Update(T entity);
    void DeleteById(T entity);

    Task<int> SaveChangesAsync();
}
