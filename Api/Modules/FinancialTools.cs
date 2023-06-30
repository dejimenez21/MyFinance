using FinancialTools.Application;
using FinancialTools.Infrastructure;

namespace Api.Modules;

internal static class FinancialTools
{
    internal static IServiceCollection RegisterFinancialToolsModule(this IServiceCollection services)
    {
        services.AddFinancialToolsApplication();
        services.AddFinancialToolsInfrastructure();

        return services;
    }
}
