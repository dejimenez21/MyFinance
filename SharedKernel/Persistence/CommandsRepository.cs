using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace SharedKernel.Persistence
{
    public abstract class CommandsRepository<TContext, TEntity> : ReadOnlyRepository<TContext, TEntity>, ICommandRepository<TEntity>, IReadOnlyRepository<TEntity> 
        where TContext : DbContext
        where TEntity : AggregateRoot
    {
        public CommandsRepository(TContext context) : base(context) { }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public virtual void DeleteById(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Insert(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

#pragma warning disable CS8603 // Possible null reference return.
        public override async Task<TEntity> GetByIdAsync(Guid id)
            => await _context.Set<TEntity>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
    }
}
