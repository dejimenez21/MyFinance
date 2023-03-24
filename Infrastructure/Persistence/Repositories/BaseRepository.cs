using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.

        
    }
}
