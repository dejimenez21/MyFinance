using SharedKernel.Domain.ValueObjects;

namespace SharedKernel.Domain.Services.AccountBalance
{
    public interface IAccountBalanceService
    {
        Task<Money> GetAccountBalance(Guid accountId);
        Task<Dictionary<Guid, Money>> GetAccountsBalances(IEnumerable<Guid> accountIds);
    }
}
