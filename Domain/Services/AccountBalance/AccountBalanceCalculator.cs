using Domain.Abstractions;
using Domain.Entities;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Services.AccountBalance
{
    // This domain service approach was selected because there might be a change in the balance calculation process in the foreseeable future.
    public class AccountBalanceCalculator : IAccountBalanceService
    {
        private readonly IAccountMovementsRepository _movementsRepository;
        private readonly IAccountsRepository _accountRepository;

        public AccountBalanceCalculator(IAccountMovementsRepository movementsRepository, IAccountsRepository accountRepository)
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

        public async Task<Dictionary<Account, Money>> GetAccountsBalances(IEnumerable<Guid> accountIds)
        {
            var movements = await _movementsRepository.GetMovementsByMultipleAccountIds(accountIds);
            var accounts = await _accountRepository.GetByIdsAsync(accountIds.ToArray());

            var groupedMovements = movements.GroupBy(m => accounts.Find(a => a.Id == m.Id));

            var accountsBalances = accounts.ToDictionary(
                account => account,
                account => new Money(account.OpeningBalance, account.Currency)
            );

            foreach (var group in groupedMovements)
            {
                var balance = group.Select(m => m.Amount).Aggregate((prev, actual) => prev + actual);
                accountsBalances[group.Key!] += balance;
            }

            return accountsBalances;
        }
    }
}
