using Domain.Abstractions;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext as Singleton?
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IAccountRepository, AccountsRepository>();
            services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
            services.AddScoped<ICreditCardsRepository, CreditCardsRepository>();
            services.AddScoped<IAccountMovementsRepository, AccountMovementsRepository>();

            return services;
        }
    }
}