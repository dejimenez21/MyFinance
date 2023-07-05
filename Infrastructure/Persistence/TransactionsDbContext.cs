using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence;

namespace Infrastructure
{
    public class TransactionsDbContext : ApplicationDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountEntry> AccountMovements { get; set; }

        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("TRNX");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransactionsDbContext).Assembly);

        }

        public async Task<int> CommitChanges()
        {
            return await SaveChangesAsync();
        }
    }
}