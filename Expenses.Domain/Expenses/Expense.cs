using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Expenses.Domain.Expenses;

public class Expense : AggregateRoot
{
    public Money Amount { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public ExpenseCategory Category { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid TransactionId { get; private set; }
    public Guid? GroupId { get; private set; }

    public Expense(Money amount, string description, DateTime date, ExpenseCategory category, Guid accountId, Guid transactionId, Guid? groupId = null)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Description = description;
        Date = date;
        Category = category;
        AccountId = accountId;
        TransactionId = transactionId;
        GroupId = groupId;
    }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Expense()
    {

    }
}
