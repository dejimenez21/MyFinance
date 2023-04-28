using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface ITransactionsRepository : ICommandRepository<Transaction>
    {
    }
}
