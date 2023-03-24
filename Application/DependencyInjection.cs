using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Application.UseCases.Expenses.List).Assembly));

            services.AddAutoMapper(typeof(Application.Dtos.LiquidAccountDto).Assembly);

            return services;
        }
    }
}