using Domain.Entities;

namespace Domain.Abstractions
{
    public interface ICreditCardsRepository : ICommandRepository<BankAccount>, IRepository<BankAccount>
    {
    }
}
