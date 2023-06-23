using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Persistence;

namespace MyFinance.ArchitetureTests.Infrastructure;

public class DbContextInheritanceTests
{
    [Fact]
    public void AllDbContexts_ShouldInheritFrom_CustomDbContextBase()
    {
        // Get the assembly for each module
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        // For each assembly...
        foreach (var assembly in assemblies)
        {
            // Get all types that are DbContexts and aren't the base DbContext or your custom DbContext
            var dbContextTypes = assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(DbContext)) && t != typeof(DbContext) && t != typeof(ApplicationDbContext));

            // For each of these types...
            foreach (var type in dbContextTypes)
            {
                // Assert that the type is a subclass of your custom DbContext
                Assert.True(type.IsSubclassOf(typeof(ApplicationDbContext)), $"{type.Name} does not inherit from ApplicationDbContext");
            }
        }
    }
}
