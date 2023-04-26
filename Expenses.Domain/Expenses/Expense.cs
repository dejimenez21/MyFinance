using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;
using System.Transactions;

namespace Expenses.Domain.Expenses;

public class Expense : Entity
{
    public Money Amount { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public ExpenseCategory Category { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid? GroupId { get; private set; }

    private Expense()
    {

    }

    public Expense(Money amount, string description, DateTime date, ExpenseCategory category, Guid accountId, Guid transactionId, Guid? groupId)
    {
        Amount = amount;
        Description = description;
        Date = date;
        Category = category;
        AccountId = accountId;
        TransactionId = transactionId;
        GroupId = groupId;
    }
}