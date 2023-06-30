using FinancialTools.Domain.BankAccounts;
using SharedKernel.Infrastructure.Persistence;

namespace FinancialTools.Infrastructure.Persistence.Repositories;

public class BankAccountRepository : CommandsRepository<FinancialToolsDbContext, BankAccount>, IBankAccountRepository
{
    public BankAccountRepository(FinancialToolsDbContext dbContext) : base(dbContext)
    {
        
    }
}
