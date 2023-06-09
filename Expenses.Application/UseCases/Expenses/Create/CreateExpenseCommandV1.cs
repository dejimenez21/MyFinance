using Expenses.Domain.Expenses;
using MediatR;
using SharedKernel.Common;

namespace Expenses.Application.UseCases.Expenses.Create;

public record CreateExpenseCommandV1(
    MoneyDto Amount,
    string Description,
    DateTime Date,
    string Category,
    Guid AccountId,
    Guid? GroupId)
    : IRequest<Result<Expense>>
{ }