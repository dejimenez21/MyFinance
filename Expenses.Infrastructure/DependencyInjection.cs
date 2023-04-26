using Domain.Abstractions;
using Expenses.Domain.Accounts;
using Expenses.Infrastructure.Persistence;
using Expenses.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExpensesInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext as Singleton?
            services.AddDbContext<ExpensesDbContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();

            return services;
        }
    }
}