using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(UseCases.Accounts.GetLiquidAccountsSummary).Assembly));

            services.AddAutoMapper(typeof(Dtos.LiquidAccountDto).Assembly);

            return services;
        }
    }
}