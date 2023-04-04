using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Services.AccountBalance;
using Domain.ValueObjects;
using FluentAssertions;
using Moq;

namespace Tests.Domain.Services.AccountBalance
{
    public class AccountBalanceCalculatorTests
    {
        private readonly Mock<IAccountMovementsRepository> _movementsRepositoryMock;
        private readonly Mock<IAccountRepository> _accountRepositoryMock;
        private readonly AccountBalanceCalculator _accountBalanceCalculator;

        public AccountBalanceCalculatorTests()
        {
            _accountRepositoryMock = new Mock<IAccountRepository>();
            _movementsRepositoryMock = new Mock<IAccountMovementsRepository>();
            _accountBalanceCalculator = new AccountBalanceCalculator(_movementsRepositoryMock.Object, _accountRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAccountBalance_ShouldCalculateBalanceCorrectly()
        {
            // Arrange
            var accountId = Guid.NewGuid();
            var account = new Account("Test Account", Application.Domain.Enums.AccountType.Asset, "4243213", CurrencyCode.USD, DateTime.Now, 500m);
            var movements = new List<AccountMovement>
            {
                new AccountMovement(accountId, Guid.NewGuid(), new Money(100, CurrencyCode.USD)),
                new AccountMovement(accountId, Guid.NewGuid(), new Money(-50, CurrencyCode.USD)),
                new AccountMovement(accountId, Guid.NewGuid(), new Money(25, CurrencyCode.USD))
            };

            var movementsRepoMock = new Mock<IAccountMovementsRepository>();
            movementsRepoMock.Setup(repo => repo.GetMovementsByAccountId(accountId)).ReturnsAsync(movements);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetByIdAsync(accountId)).ReturnsAsync(account);

            var balanceService = new AccountBalanceCalculator(movementsRepoMock.Object, accountRepoMock.Object);

            // Act
            var balance = await balanceService.GetAccountBalance(accountId);

            // Assert
            balance.Should().Be(new Money(575, CurrencyCode.USD));
        }

        [Fact]
        public async Task GetAccountsBalances_ShouldCalculateBalancesCorrectly()
        {
            // Arrange
            
            var account1 = new Account("Test Account 1", Application.Domain.Enums.AccountType.Asset, "4243213", CurrencyCode.USD, DateTime.Now, 500m);
            var accountId1 = account1.Id;
            var account2 = new Account("Test Account 2", Application.Domain.Enums.AccountType.Asset, "42477213213", CurrencyCode.USD, DateTime.Now, 1000m);
            var accountId2 = account2.Id;

            var accountIds = new List<Guid> { accountId1, accountId2 };

            var movements = new List<AccountMovement>
            {
                new AccountMovement(accountId1, Guid.NewGuid(), new Money(100, CurrencyCode.USD)),
                new AccountMovement(accountId1, Guid.NewGuid(), new Money(-50, CurrencyCode.USD)),
                new AccountMovement(accountId1, Guid.NewGuid(), new Money(25, CurrencyCode.USD)),
                new AccountMovement(accountId2, Guid.NewGuid(), new Money(-200, CurrencyCode.USD)),
                new AccountMovement(accountId2, Guid.NewGuid(), new Money(150, CurrencyCode.USD))
            };

            var movementsRepoMock = new Mock<IAccountMovementsRepository>();
            movementsRepoMock.Setup(repo => repo.GetMovementsByMultipleAccountIds(accountIds)).ReturnsAsync(movements);

            var accountRepoMock = new Mock<IAccountRepository>();
            accountRepoMock.Setup(repo => repo.GetByIdsAsync(accountIds.ToArray())).ReturnsAsync(new List<Account> { account1, account2 });

            var balanceService = new AccountBalanceCalculator(movementsRepoMock.Object, accountRepoMock.Object);

            // Act
            var balances = await balanceService.GetAccountsBalances(accountIds);

            // Assert
            balances[accountId1].Should().Be(new Money(575, CurrencyCode.USD));
            balances[accountId2].Should().Be(new Money(950, CurrencyCode.USD));
        }
    }
}