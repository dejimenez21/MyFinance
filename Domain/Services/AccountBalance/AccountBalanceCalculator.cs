using Domain.Abstractions;
using SharedKernel.Domain.Services.AccountBalance;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Services.AccountBalance
{
    // This domain service approach was selected because there might be a change in the balance calculation process in the foreseeable future.
    public class AccountBalanceCalculator : IAccountBalanceService
    {
        private readonly IAccountMovementsRepository _movementsRepository;
        private readonly IAccountRepository _accountRepository;

        public AccountBalanceCalculator(IAccountMovementsRepository movementsRepository, IAccountRepository accountRepository)
        {
            _movementsRepository = movementsRepository;
            _accountRepository = accountRepository;
        }
        public async Task<Money> GetAccountBalance(Guid accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            var movements = await _movementsRepository.GetMovementsByAccountId(accountId);

            return movements.Select(m => m.Amount).Aggregate((prev, actual) => prev + actual) + new Money(account.OpeningBalance, account.Currency);
        }

        public async Task<Dictionary<Guid, Money>> GetAccountsBalances(IEnumerable<Guid> accountIds)
        {
            var movements = await _movementsRepository.GetMovementsByMultipleAccountIds(accountIds);
            var accounts = await _accountRepository.GetByIdsAsync(accountIds.ToArray());

            var groupedMovements = movements.GroupBy(m => m.AccountId);

            var accountsBalances = accounts.ToDictionary(
                account => account.Id,
                account => new Money(account.OpeningBalance, account.Currency)
            );

            foreach (var group in groupedMovements)
            {
                var balance = group.Select(m => m.Amount).Aggregate((prev, actual) => prev + actual);

                accountsBalances[group.Key] += balance;
            }

            return accountsBalances;
        }
    }
}
