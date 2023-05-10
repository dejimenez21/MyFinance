using Expenses.Domain;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using MediatR;
using SharedKernel.Application.Commands.Transactions;
using SharedKernel.Common;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Expenses.Application.UseCases.Expenses.Create
{
    internal class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Result<Expense>>
    {
        private readonly IExpenseGroupsRepository _expensesGroupsRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IMediator _mediator;

        public CreateExpenseCommandHandler(IExpenseGroupsRepository expensesGroupRepository, IExpensesRepository expensesRepository, IMediator mediator)
        {
            _expensesGroupsRepository = expensesGroupRepository;
            _expensesRepository = expensesRepository;
            _mediator = mediator;
        }

        public async Task<Result<Expense>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var validCurrency = Enum.TryParse<CurrencyCode>(request.Amount.Currency, true, out var currency);
            if (!validCurrency) 
                return Errors.Currencies.InvalidCurrency(request.Amount.Currency);

            var expenseAmount = new Money(request.Amount.Value, currency);

            ExpenseGroup? expenseGroup = null;

            if (request.GroupId.HasValue)
            {
                expenseGroup = await _expensesGroupsRepository.GetByIdAsync(request.GroupId.Value);
                if (expenseGroup is null)
                {
                    return Errors.Common.NotFound(typeof(ExpenseGroup).Name, request.GroupId.Value);
                }
            }

            //TODO: Validate that expense is created with a Date in the past.

            var transactionResult = await _mediator.Send(
                new CreateExpenseTransactionCommand(
                    Description: request.Description,
                    Amount: expenseAmount,
                    PaymentAccountId: request.AccountId,
                    ExpenseAccountId: expenseGroup?.ExpenseAccountId,
                    Date: request.Date)
            );

            if (transactionResult.IsFailed)
            {
                //TODO: Check logging mechanism of the Result object as well as mediatr interceptor for logging.
                return Errors.Expenses.CreateTransactionFailed(transactionResult.Error!);
            }

            var expense = new Expense(
                amount: expenseAmount,
                description: request.Description,
                date: request.Date,
                category: Enumeration.FromName<ExpenseCategory>(request.Category),
                accountId: request.AccountId,
                transactionId: transactionResult.Value);

            _expensesRepository.Insert(expense);
            await _expensesRepository.SaveChangesAsync();

            return expense;
        }
    }
}
