using Expenses.Infrastructure.Persistence;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void InitializeDatabase(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        try
        {
            var transactionsContext = scope.ServiceProvider.GetRequiredService<TransactionsDbContext>();
            transactionsContext.Database.Migrate();
            var expensesContext = scope.ServiceProvider.GetRequiredService<ExpensesDbContext>();
            expensesContext.Database.Migrate();
            Seed.SeedData(transactionsContext, expensesContext);
        }
        catch (Exception ex)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration");
        }
        
    }
}