using Ardalis.GuardClauses;
using Expenses.Domain.Expenses;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Domain.ExpenseGroups
{
    public sealed class ExpenseGroup : AggregateRoot
    {
        private HashSet<Expense> _expenses;

        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid ExpenseAccountId { get; set; }
        public IReadOnlyCollection<Expense> Expenses => _expenses;

        public ExpenseGroup(string name, string description, Guid expenseAccountId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            ExpenseAccountId = expenseAccountId;
            _expenses = new HashSet<Expense>();
        }

        private ExpenseGroup() { }

        public Expense AddExpense(Money amount,
            string description,
            DateTime date,
            ExpenseCategory category,
            Guid accountId,
            Guid transactionId)
        {
            //TODO: Add Guard clauses validations
            var expense = new Expense(
                amount: amount,
                description: description,
                date: date,
                category: category,
                accountId: accountId,
                transactionId: transactionId,
                groupId: Id
            );
            _expenses.Add(expense);
            return expense;
        }
    }
}
