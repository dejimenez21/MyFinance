using Application.Core.Abstractions;
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
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Expense> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Expenses.Add(request.Expense);
                await _context.CommitChanges();

                return request.Expense;
            }
        }
    }
}
