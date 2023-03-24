using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
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
