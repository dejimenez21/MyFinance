using Domain.Abstractions;
using Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTransactionsInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IBankAccountsRepository, BankAccountsRepository>();
            services.AddScoped<ICreditCardsRepository, CreditCardsRepository>();
            services.AddScoped<IAccountMovementsRepository, AccountMovementsRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            return services;
        }
    }
}