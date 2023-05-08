using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions;

public interface ICreditCardsRepository : ICommandRepository<CreditCard>, IReadRepository<CreditCard>
{
}
