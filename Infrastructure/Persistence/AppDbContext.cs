using Application.Core.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}