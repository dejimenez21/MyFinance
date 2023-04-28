using Application.Domain.Enums;
using Domain;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using SharedKernel.Application.Commands.Transactions;
using SharedKernel.Common;
using SharedKernel.Domain.ValueObjects;

namespace Application.UseCases.Transactions.Synced
{
    public class CreateExpenseTransactionHandler : IRequestHandler<CreateExpenseTransactionCommand, Result<Guid>>
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly ITransactionsRepository _transactionsRepository;

        public CreateExpenseTransactionHandler(IAccountsRepository accountsRepository, ITransactionsRepository transactionsRepository)
        {
            _accountsRepository = accountsRepository;
            _transactionsRepository = transactionsRepository;
        }
        public async Task<Result<Guid>> Handle(CreateExpenseTransactionCommand request, CancellationToken cancellationToken)
        {
            var expenseAccount = await _accountsRepository.GetByIdAsync(request.ExpenseAccountId)  
                ?? await _accountsRepository.GetAcccountByName(AccountType.Expense.DefaultAccountName);

            if(expenseAccount is null)
                return Errors.Common.NotFound(typeof(Account).Name, request.ExpenseAccountId);

            if (expenseAccount.Type != AccountType.Expense)
                return Errors.Account.IncorrectType(AccountType.Expense, request.ExpenseAccountId);

            var paymentAccount = await _accountsRepository.GetByIdAsync(request.PaymentAccountId);

            if (paymentAccount is null)
                return Errors.Common.NotFound(typeof(Account).Name, request.PaymentAccountId);

            if (!paymentAccount.IsElegibleForPayment)
                return Errors.Account.NotEligibleForPayment(paymentAccount.Name);

            var transaction = Transaction.Create(
                accountOperations: new Dictionary<Account, Money>
                {
                    {expenseAccount, request.Amount },
                    {paymentAccount, -request.Amount }
                },
                transactionDate: request.Date,
                description: request.Description
            );

            _transactionsRepository.Insert(transaction);
            await _transactionsRepository.SaveChangesAsync();

            return transaction.Id;
        }
    }
}
