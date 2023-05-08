using Expenses.Application.UseCases.Expenses.List;
using Microsoft.Extensions.DependencyInjection;


namespace Expenses.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExpensesApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ListExpensesQuery).Assembly));

            return services;
        }
    }
}