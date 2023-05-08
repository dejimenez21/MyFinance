using Domain.Abstractions;
using Domain.Entities;
using SharedKernel.Persistence;

namespace Infrastructure.Persistence.Repositories;

public class CreditCardsRepository : CommandsRepository<TransactionsDbContext, CreditCard>, ICreditCardsRepository
{
    public CreditCardsRepository(TransactionsDbContext context) : base(context)
    {
    }
}
