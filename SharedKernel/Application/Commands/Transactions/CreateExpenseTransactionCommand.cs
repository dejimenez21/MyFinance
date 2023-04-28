using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.ValueObjects;

namespace SharedKernel.Application.Commands.Transactions
{
    public sealed class CreateExpenseTransactionCommand : IRequest<Result<Guid>>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid ExpenseAccountId { get; set; }
        public Guid PaymentAccountId { get; set; }
        public Money Amount { get; set; }
    }
}
