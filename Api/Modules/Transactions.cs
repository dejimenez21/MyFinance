using Application;
using Infrastructure;

namespace Api.Modules;

internal static class Transactions
{
    internal static IServiceCollection RegisterTransactionsModule(this IServiceCollection services)
    {
        services.AddTransactionsApplication();
        services.AddTransactionsInfrastructure();

        return services;
    }
}
