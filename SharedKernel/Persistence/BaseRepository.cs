using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace SharedKernel.Persistence
{
    public abstract class BaseRepository<TContext, TEntity> : IRepository<TEntity> 
        where TContext : DbContext
        where TEntity : Entity 
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<TEntity> GetByIdAsync(Guid id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> GetByIdsAsync(Guid[] ids) => await _context.Set<TEntity>().AsNoTracking().Where(t => ids.Contains(t.Id)).ToListAsync();
#pragma warning restore CS8603 // Possible null reference return.


    }
}
