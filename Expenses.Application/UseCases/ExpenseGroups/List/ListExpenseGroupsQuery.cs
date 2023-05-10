using Expenses.Domain.ExpenseGroups;
using MediatR;
using SharedKernel.Common;

namespace Expenses.Application.UseCases.ExpenseGroups.List;

public record ListExpenseGroupsQuery() : IRequest<Result<List<ExpenseGroup>>>;
