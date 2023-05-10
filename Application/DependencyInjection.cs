using Application.UseCases.Accounts.ListLiquidAccounts;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ListLiquidAccountsQueryHandler).Assembly));

            services.AddAutoMapper(typeof(Dtos.LiquidAccountDto).Assembly);

            return services;
        }
    }
}