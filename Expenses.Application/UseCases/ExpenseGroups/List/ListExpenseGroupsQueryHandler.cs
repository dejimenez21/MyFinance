using AutoMapper;
using Expenses.Domain.ExpenseGroups;
using MediatR;
using SharedKernel.Common;

namespace Expenses.Application.UseCases.ExpenseGroups.List;

public class ListExpenseGroupsQueryHandler : IRequestHandler<ListExpenseGroupsQuery, Result<List<ExpenseGroup>>>
{
    private readonly IExpenseGroupsRepository _expenseGroupsRepository;

    public ListExpenseGroupsQueryHandler(IExpenseGroupsRepository expenseGroupsRepository)
    {
        _expenseGroupsRepository = expenseGroupsRepository;
    }
    public async Task<Result<List<ExpenseGroup>>> Handle(ListExpenseGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _expenseGroupsRepository.GetAllAsync();
    }
}
