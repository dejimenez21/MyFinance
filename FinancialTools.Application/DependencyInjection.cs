using Microsoft.Extensions.DependencyInjection;

namespace FinancialTools.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddFinancialToolsApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}