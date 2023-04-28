using Expenses.Domain.Accounts;
using Expenses.Domain.ExpenseGroups;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Infrastructure.Persistence
{
    public class ExpensesDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; private set; }
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }

        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("EXPN");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpensesDbContext).Assembly);
        }

        public async Task<int> CommitChanges()
        {
            return await SaveChangesAsync();
        }
    }
}