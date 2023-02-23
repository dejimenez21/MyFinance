using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public Expense(decimal amount, string description)
        {
            this.Amount = amount;
            this.Description = description;
            this.Id = Guid.NewGuid();
        }
    }
}