using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions;

public interface IBankAccountsRepository : ICommandRepository<BankAccount>, IReadRepository<BankAccount>
{

}
