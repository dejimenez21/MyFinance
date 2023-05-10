using Application.Domain.Enums;
using SharedKernel.Common;

namespace Domain;

public static class Errors
{
    public static class Common
    {
        public static Error NotFound(string entityName, Guid id) =>
            new(404, $"{entityName}.not.found", $"'{entityName}' not found for id '{id}'");
    }

    public static class Accounts
    {
        public static Error IncorrectType(AccountType expectedType, Guid id) =>
            new(400, "incorrect.account.type", $"The account with id '{id}' is not of type {expectedType}");

        public static Error NotEligibleForPayment(string name) =>
            new(400, "not.payment.eligible", $"The account '{name}' is not elegible for payments");
    }
}
