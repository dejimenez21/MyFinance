using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAccountRepository : ICommandRepository<Account>, IRepository<Account>
    {
        Task<List<Account>> GetCashAccounts();
    }
}
