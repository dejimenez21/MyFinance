using SharedKernel.Domain.Abstractions;

namespace FinancialTools.Domain.BankAccounts;

public interface IBankAccountRepository : ICommandRepository<BankAccount>
{
}
