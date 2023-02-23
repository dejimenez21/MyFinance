using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class Seed
    {
        public static void SeedData(AppDbContext context)
        {
            if (context.Expenses.Any()) return;

            var expenses = new List<Expense>
            {
                new Expense(500, "Supermercado"),
                new Expense(300, "Otra cosa"),
                new Expense(25000, "Acondicionador de Aire"),
                new Expense(1250, "Balon de futbol")
            };

            context.Expenses.AddRange(expenses);
            context.SaveChanges();
        }
    }
}
