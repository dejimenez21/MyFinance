using Expenses.Domain.Accounts;
using MediatR;

namespace Expenses.Application.UseCases.PaymentAccounts.List;

public class ListPaymentAccountsQueryHandler : IRequestHandler<ListPaymentAccountsQuery, List<PaymentAccount>>
{
    private readonly IPaymentAccountsRepository _paymentAccountsRepository;

    public ListPaymentAccountsQueryHandler(IPaymentAccountsRepository paymentAccountsRepository)
    {
        _paymentAccountsRepository = paymentAccountsRepository;
    }

    public async Task<List<PaymentAccount>> Handle(ListPaymentAccountsQuery request, CancellationToken cancellationToken)
    {
        return await _paymentAccountsRepository.GetAllAsync();
    }
}
