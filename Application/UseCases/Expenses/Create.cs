using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Expenses
{
    public class Create
    {
        public class Command : IRequest<Expense>
        {
#pragma warning disable CS8618
            public Expense Expense { get; set; } 
        }

        public class Handler : IRequestHandler<Command, Expense>
        {
            private readonly IExpensesRepository _expensesRepository;

            public Handler(IExpensesRepository expensesRepository)
            {
                _expensesRepository = expensesRepository;
            }

            public async Task<Expense> Handle(Command request, CancellationToken cancellationToken)
            {
                _expensesRepository.Insert(request.Expense);
                await _expensesRepository.SaveChangesAsync();

                return request.Expense;
            }
        }
    }
}
