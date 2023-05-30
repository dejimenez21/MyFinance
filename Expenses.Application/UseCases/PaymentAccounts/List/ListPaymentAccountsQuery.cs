using Expenses.Domain.Accounts;
using MediatR;

namespace Expenses.Application.UseCases.PaymentAccounts.List;

public record ListPaymentAccountsQuery : IRequest<List<PaymentAccount>>
{
}
