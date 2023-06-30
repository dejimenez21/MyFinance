using FinancialTools.Domain.BankAccounts;
using FinancialTools.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTools.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddFinancialToolsInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();

        return services;
    }
}
