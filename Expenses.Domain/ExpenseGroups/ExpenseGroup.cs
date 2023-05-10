using SharedKernel.Domain.Primitives;

namespace Expenses.Domain.ExpenseGroups;

public sealed class ExpenseGroup : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid ExpenseAccountId { get; set; }

    public ExpenseGroup(string name, string description, Guid expenseAccountId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        ExpenseAccountId = expenseAccountId;
    }

    private ExpenseGroup() { }
}
