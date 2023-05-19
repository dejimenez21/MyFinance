using FinancialTools.Domain.BankAccounts;
using FinancialTools.Domain.CashAccounts;
using FinancialTools.Domain.CreditCards;
using Microsoft.EntityFrameworkCore;

namespace FinancialTools.Infrastructure.Persistence
{
    public class FinancialToolsDbContext : DbContext
    {
        public DbSet<CashAccount> CashAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCardAccount> CreditCardAccounts { get; set; }

        public FinancialToolsDbContext(DbContextOptions<FinancialToolsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("FNCT");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialToolsDbContext).Assembly);

        }

        public async Task<int> CommitChanges()
        {
            return await SaveChangesAsync();
        }
    }
}