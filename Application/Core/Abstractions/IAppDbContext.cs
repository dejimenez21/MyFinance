using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Abstractions
{
    //This is temporal, while i decide wich entities are going to have repositories.
    public interface IAppDbContext
    {
        DbSet<Expense> Expenses { get; }
    }
}
