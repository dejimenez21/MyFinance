
using Application.Core.Abstractions;
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
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Expense>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Expenses.ToListAsync();
            }
        }
    }
}
