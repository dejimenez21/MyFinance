using Expenses.Domain.Accounts;
using Expenses.Domain.ExpenseGroups;
using Expenses.Domain.Expenses;
using Expenses.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExpensesInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IExpenseGroupsRepository, ExpenseGroupsRepository>();
            services.AddScoped<IExpensesRepository, ExpensesRepository>();
            services.AddScoped<IPaymentAccountsRepository, AccountsRepository>();

            return services;
        }
    }
}