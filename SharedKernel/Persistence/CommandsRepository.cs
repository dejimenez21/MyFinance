using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace SharedKernel.Persistence;

public abstract class CommandsRepository<TContext, TEntity> : ICommandRepository<TEntity>, IReadRepository<TEntity> 
    where TContext : DbContext
    where TEntity : AggregateRoot
{
    protected readonly TContext _context;

    public CommandsRepository(TContext context)
    {
        _context = context;
    }

    public virtual async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public virtual void DeleteById(TEntity entity) => _context.Set<TEntity>().Remove(entity);

    public virtual void Insert(TEntity entity) => _context.Add(entity);

    public virtual void Update(TEntity entity) => _context.Update(entity);

#pragma warning disable CS8603 // Possible null reference return.

    public async Task<TEntity> GetByIdAsync(Guid id)
        => await GetWithIncludeAll().FirstOrDefaultAsync(e => e.Id == id);
        //=> await _context.Set<TEntity>().FindAsync(id);

    public async Task<List<TEntity>> GetAllAsync() => 
        await GetWithIncludeAll().ToListAsync();

    public async Task<List<TEntity>> GetByIdsAsync(Guid[] ids)
        => await GetWithIncludeAll().Where(e => ids.Contains(e.Id)).ToListAsync();

#pragma warning restore CS8603 // Possible null reference return.


    protected internal IQueryable<TEntity> GetWithIncludeAll()
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        IEnumerable<INavigation> navigationProperties = _context.Model.FindEntityType(typeof(TEntity))!.GetNavigations();
        if (navigationProperties == null)
            return query;

        foreach (INavigation navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty.Name);
        }

        return query;
    }
}
