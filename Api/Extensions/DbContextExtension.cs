using Expenses.Infrastructure.Persistence;
using FinancialTools.Infrastructure.Persistence;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class DbContextExtension
{
    public static void RegisterAllDbContexts(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        // Register DbContext as Singleton?
        if (env.IsEnvironment("Local"))
        {
            services.AddDbContext<ExpensesDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TransactionsDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<FinancialToolsDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
        else
        {
            services.AddDbContext<ExpensesDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TransactionsDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<FinancialToolsDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
