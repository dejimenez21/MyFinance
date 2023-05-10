using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace SharedKernel.Persistence;

#pragma warning disable CS8603 // Possible null reference return.

public abstract class ReadOnlyRepository<TContext, TEntity> : IReadRepository<TEntity> 
    where TContext : DbContext
    where TEntity : Entity 
{
    protected readonly TContext _context;

    public ReadOnlyRepository(TContext context)
    {
        _context = context;
    }

    public async Task<List<TEntity>> GetAllAsync() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

    public async virtual Task<TEntity> GetByIdAsync(Guid id) => 
        await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

    public async Task<List<TEntity>> GetByIdsAsync(Guid[] ids) => await _context.Set<TEntity>().AsNoTracking().Where(t => ids.Contains(t.Id)).ToListAsync();
}
