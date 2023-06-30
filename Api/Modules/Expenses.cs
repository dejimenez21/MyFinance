using Expenses.Application;
using Expenses.Infrastructure;

namespace Api.Modules;

internal static class Expenses
{
    internal static IServiceCollection RegisterExpensesModule(this IServiceCollection services)
    {
        services.AddExpensesApplication();
        services.AddExpensesInfrastructure();

        return services;
    }
}
