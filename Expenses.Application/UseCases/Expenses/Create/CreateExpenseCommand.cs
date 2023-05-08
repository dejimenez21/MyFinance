using Expenses.Domain.Expenses;
using MediatR;
using SharedKernel.Common;

namespace Expenses.Application.UseCases.Expenses.Create;

public record CreateExpenseCommand(
    MoneyDto Amount,
    string Description,
    DateTime Date,
    string Category,
    Guid AccountId,
    Guid? GroupId) 
    : IRequest<Result<Expense>> { }
    
public record MoneyDto(decimal Value, string Currency);
