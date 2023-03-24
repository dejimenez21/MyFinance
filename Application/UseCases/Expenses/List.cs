using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Expenses
{
    public class List
    {
        public class Query : IRequest<List<Expense>> { }

        public class Handler : IRequestHandler<Query, List<Expense>>
        {
            private readonly IExpensesRepository _expensesRepository;

            public Handler(IExpensesRepository expensesRepository)
            {
                _expensesRepository = expensesRepository;
            }

            public async Task<List<Expense>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _expensesRepository.GetAllAsync();
            }
        }
    }
}
