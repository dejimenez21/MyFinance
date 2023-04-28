using SharedKernel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Application.Dtos
{
    public record ExpenseCreateDto(Money Amount, string Description, DateTime Date, string Category, Guid AccountId, Guid GroupId);
}
