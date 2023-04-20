using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace Infrastructure.Persistence.Repositories.Shared
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetByIdsAsync(Guid[] ids) => await _context.Set<T>().AsNoTracking().Where(t => ids.Contains(t.Id)).ToListAsync();
#pragma warning restore CS8603 // Possible null reference return.


    }
}
