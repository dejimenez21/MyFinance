using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IAccountsRepository : ICommandRepository<Account>, IReadOnlyRepository<Account>
    {
        Task<List<Account>> GetCashAccounts();
        Task<Account> GetAcccountByName(string name);
    }
}
