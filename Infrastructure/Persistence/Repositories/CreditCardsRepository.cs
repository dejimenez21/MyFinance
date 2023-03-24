using Domain.Abstractions;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class CreditCardsRepository : CommandsRepository<BankAccount>, ICreditCardsRepository
    {
        public CreditCardsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
