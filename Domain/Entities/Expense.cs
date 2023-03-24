using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense : Entity
    {
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }

        public Expense(decimal amount, string description)
        {
            this.Amount = amount;
            this.Description = description;
            this.Id = Guid.NewGuid();
        }

        private Expense()
        {
            
        }
    }
}