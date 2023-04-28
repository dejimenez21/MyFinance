using SharedKernel.Common;

namespace Expenses.Domain;

public static class Errors
{
    public static class Common
    {
        public static Error NotFound(string entityName, Guid id) =>
            new(404, $"{entityName}.not.found", $"'{entityName}' not found for id '{id}'");
    }

    public static class Expense
    {
        public static Error CreateTransactionFailed(Error reason) =>
            reason is not null ?
                new(reason.StatusCode, "create.transaction.failed", "An error has occured while creating transaction", reason) :
                new(500, "create.transaction.failed", "An error has occured while creating transaction");
    }
}
