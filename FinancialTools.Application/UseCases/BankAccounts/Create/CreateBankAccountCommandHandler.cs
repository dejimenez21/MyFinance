using FinancialTools.Domain.BankAccounts;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.Enums;

namespace FinancialTools.Application.UseCases.BankAccounts.Create;

public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Result<BankAccount>>
{
    private readonly IBankAccountRepository _bankAccountRepository;

    public CreateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }
    public async Task<Result<BankAccount>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = new BankAccount
            (
                request.Name,
                request.Number,
                Enum.Parse<BankCode>(request.Bank),
                Enum.Parse<CurrencyCode>(request.Currency),
                Enum.Parse<BankAccountType>(request.Type)
            );

        _bankAccountRepository.Insert( bankAccount );
        await _bankAccountRepository.SaveChangesAsync();

        //TODO: Push event notifications

        return bankAccount;
    }
}
