using Domain.Abstractions;
using Domain.Entities;
using SharedKernel.Infrastructure.Persistence;

namespace Infrastructure.Persistence.Repositories;

public class TransactionsRepository : CommandsRepository<TransactionsDbContext, Transaction>, ITransactionsRepository
{
    public TransactionsRepository(TransactionsDbContext context) : base(context)
    {
        
    }
}
