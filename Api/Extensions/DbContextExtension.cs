using Expenses.Infrastructure.Persistence;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace Api.Extensions;

public static class DbContextExtension
{
    public static void RegisterAllDbContexts(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        // Register DbContext as Singleton?
        if (env.IsDevelopment())
        {
            services.AddDbContext<ExpensesDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TransactionsDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        }
        else if(env.IsStaging())
        {
            services.AddDbContext<ExpensesDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TransactionsDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
