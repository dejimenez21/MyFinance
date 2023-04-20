using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IAccountRepository : ICommandRepository<Account>, IRepository<Account>
    {
        Task<List<Account>> GetCashAccounts();
    }
}
