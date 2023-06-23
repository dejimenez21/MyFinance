using Expenses.Domain.Accounts;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence;

namespace Expenses.Infrastructure.Persistence
{
    public class ExpensesDbContext : ApplicationDbContext
    {
        public DbSet<Expense> Expenses { get; private set; }
        public DbSet<ExpenseGroup> ExpenseGroups { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }

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