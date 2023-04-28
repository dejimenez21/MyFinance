using Expenses.Application.Dtos;
using Expenses.Domain;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using MediatR;
using SharedKernel.Application.Commands.Transactions;
using SharedKernel.Common;

namespace Expenses.Application.UseCases.Expenses;

public class Create
{
    public class Command : IRequest<Result<Expense>>
    {
#pragma warning disable CS8618
        public ExpenseCreateDto Expense { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Expense>>
    {
        private readonly IExpenseGroupsRepository _expensesGroupsRepository;
        private readonly IMediator _mediator;

        public Handler(IExpenseGroupsRepository expensesGroupRepository, IMediator mediator)
        {
            _expensesGroupsRepository = expensesGroupRepository;
            _mediator = mediator;
        }

        public async Task<Result<Expense>> Handle(Command request, CancellationToken cancellationToken)
        {
            var expenseGroup = await _expensesGroupsRepository.GetByIdAsync(request.Expense.GroupId);
            if (expenseGroup is null)
            {
                return Errors.Common.NotFound(typeof(ExpenseGroup).Name, request.Expense.GroupId);
            }

            //TODO: Validate that expense is created with a Date in the past.

            var transactionResult = await _mediator.Send(new CreateExpenseTransactionCommand
            {
                Description = request.Expense.Description,
                Amount = request.Expense.Amount,
                PaymentAccountId = request.Expense.AccountId,
                ExpenseAccountId = expenseGroup.ExpenseAccountId,
                Date = request.Expense.Date
            });

            if(transactionResult.IsFailed)
            {
                //TODO: Check logging mechanism of the Result object as well as mediatr interceptor for logging.
                return Errors.Expense.CreateTransactionFailed(transactionResult.Error!);
            }

            var expense = expenseGroup.AddExpense(
                amount: request.Expense.Amount, 
                description: request.Expense.Description, 
                date: request.Expense.Date,
                category: Enum.Parse<ExpenseCategory>(request.Expense.Category), 
                accountId: request.Expense.AccountId,
                transactionId: transactionResult.Value);

            await _expensesGroupsRepository.SaveChangesAsync();

            return expense;
        }
    }
}
