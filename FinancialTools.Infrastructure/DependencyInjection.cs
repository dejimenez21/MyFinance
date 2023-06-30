using FinancialTools.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialTools.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddFinancialToolsInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinancialToolsDbContext>(x => x.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
