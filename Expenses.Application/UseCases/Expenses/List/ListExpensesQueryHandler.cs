using Expenses.Domain.Expenses;
using MediatR;

namespace Expenses.Application.UseCases.Expenses.List;

internal class ListExpensesQueryHandler : IRequestHandler<ListExpensesQuery, List<Expense>>
{
    private readonly IExpensesRepository _expensesRepository;

    public ListExpensesQueryHandler(IExpensesRepository expensesRepository)
    {
        _expensesRepository = expensesRepository;
    }

    public async Task<List<Expense>> Handle(ListExpensesQuery request, CancellationToken cancellationToken)
    {
        return await _expensesRepository.GetAllAsync();
    }
}