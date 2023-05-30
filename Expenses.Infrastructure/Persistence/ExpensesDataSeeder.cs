using Bogus;
using Expenses.Domain.Expenses;
using Expenses.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

public class ExpensesDataSeeder
{
    private readonly ExpensesDbContext _context;
    public ExpensesDataSeeder(ExpensesDbContext context)
    {
        _context = context;
    }

    public async Task SeedDataAsync()
    {
        if (!_context.Expenses.Any())
        {
            var categories = Enumeration.GetAll<ExpenseCategory>();
            var accounts = await _context.PaymentAccounts.ToListAsync();

            var faker = new Faker<Expense>()
                .StrictMode(true)
                .RuleFor(e => e.Amount, f => new Money(f.Random.Decimal(1, 6000), CurrencyCode.USD))
                .RuleFor(e => e.Description, f => f.Lorem.Sentence(5))
                .RuleFor(e => e.Date, f => f.Date.Past(1))
                .RuleFor(e => e.Category, f => f.PickRandom(categories))
                .RuleFor(e => e.AccountId, f => f.PickRandom(accounts).Id)
                .RuleFor(e => e.TransactionId, f => f.Random.Guid())
                .RuleFor(e => e.GroupId, f => f.Random.Bool() ? f.Random.Guid() : null);

            var expenses = faker.Generate(100);

            foreach (var expense in expenses)
            {
                _context.Expenses.Add(expense);
            }

            await _context.SaveChangesAsync();
        }
    }
}