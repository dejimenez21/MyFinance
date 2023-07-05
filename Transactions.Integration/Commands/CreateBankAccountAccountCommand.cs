using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.Enums;

namespace Transactions.Integration.Commands;

public record CreateBankAccountAccountCommand(
    string Name,
    string Number,
    CurrencyCode Currency
) : IRequest<Result<Guid>> {}
