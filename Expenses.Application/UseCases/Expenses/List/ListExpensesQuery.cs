using Expenses.Domain.Expenses;
using MediatR;

namespace Expenses.Application.UseCases.Expenses.List;

public record ListExpensesQuery : IRequest<List<Expense>> { }