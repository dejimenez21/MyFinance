using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Shared
{
    public abstract class CommandsRepository<T> : BaseRepository<T>, ICommandRepository<T> where T : Entity
    {
        public CommandsRepository(AppDbContext context) : base(context) { }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
