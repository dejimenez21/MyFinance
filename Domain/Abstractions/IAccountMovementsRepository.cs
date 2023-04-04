using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IAccountMovementsRepository : IRepository<AccountMovement>
    {
        Task<IEnumerable<AccountMovement>> GetMovementsByAccountId(Guid accountId);
        Task<IEnumerable<AccountMovement>> GetMovementsByMultipleAccountIds(IEnumerable<Guid> accountIds);
    }
}
