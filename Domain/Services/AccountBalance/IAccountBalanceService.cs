using Domain.Entities;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Services.AccountBalance;

public interface IAccountBalanceService
{
    Task<Money> GetAccountBalance(Guid accountId);
    Task<Dictionary<Account, Money>> GetAccountsBalances(IEnumerable<Guid> accountIds);
}
