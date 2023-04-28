﻿using Expenses.Domain.Accounts;
using SharedKernel.Persistence;

namespace Expenses.Infrastructure.Persistence.Repositories
{
    public sealed class AccountsRepository : CommandsRepository<ExpensesDbContext, PaymentAccount>, IAccountsRepository
    {
        public AccountsRepository(ExpensesDbContext context) : base(context)
        {
        }

    }
}