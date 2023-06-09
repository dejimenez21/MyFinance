using Expenses.Domain;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Expenses.Application.UseCases.Expenses.Create
{
    internal class CreateExpenseCommandHandlerV1 : IRequestHandler<CreateExpenseCommandV1, Result<Expense>>
    {
        private readonly IExpenseGroupsRepository _expensesGroupsRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IMediator _mediator;

        public CreateExpenseCommandHandlerV1(IExpenseGroupsRepository expensesGroupRepository, IExpensesRepository expensesRepository, IMediator mediator)
        {
            _expensesGroupsRepository = expensesGroupRepository;
            _expensesRepository = expensesRepository;
            _mediator = mediator;
        }

        public async Task<Result<Expense>> Handle(CreateExpenseCommandV1 request, CancellationToken cancellationToken)
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

            var expense = new Expense(
                amount: expenseAmount,
                description: request.Description,
                date: request.Date,
                category: Enumeration.FromName<ExpenseCategory>(request.Category),
                accountId: request.AccountId,
                transactionId: default);

            _expensesRepository.Insert(expense);
            await _expensesRepository.SaveChangesAsync();

            return expense;
        }
    }
}
