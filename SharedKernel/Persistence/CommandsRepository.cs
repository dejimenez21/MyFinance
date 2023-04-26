using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Abstractions;
using SharedKernel.Domain.Primitives;

namespace SharedKernel.Persistence
{
    public abstract class CommandsRepository<TContext, TEntity> : BaseRepository<TContext, TEntity>, ICommandRepository<TEntity> 
        where TContext : DbContext
        where TEntity : Entity
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
    }
}
