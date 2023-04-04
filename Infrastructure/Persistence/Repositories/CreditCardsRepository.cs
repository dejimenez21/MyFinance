using Domain.Abstractions;
using Domain.Entities;
using Infrastructure.Persistence.Repositories.Shared;

namespace Infrastructure.Persistence.Repositories
{
    public class CreditCardsRepository : CommandsRepository<BankAccount>, ICreditCardsRepository
    {
        public CreditCardsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
