using Domain.ValueObjects;

namespace Domain.Services.AccountBalance
{
    public interface IAccountBalanceService
    {
        Task<Money> GetAccountBalance(Guid accountId);
        Task<Dictionary<Guid, Money>> GetAccountsBalances(IEnumerable<Guid> accountIds);
    }
}
