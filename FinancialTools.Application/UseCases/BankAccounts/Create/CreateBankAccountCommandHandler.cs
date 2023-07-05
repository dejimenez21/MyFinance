using FinancialTools.Domain.BankAccounts;
using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.Enums;
using Transactions.Integration.Commands;

namespace FinancialTools.Application.UseCases.BankAccounts.Create;

public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Result<BankAccount>>
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ISender _sender;

    public CreateBankAccountCommandHandler(IBankAccountRepository bankAccountRepository, ISender sender)
    {
        _bankAccountRepository = bankAccountRepository;
        _sender = sender;
    }
    public async Task<Result<BankAccount>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        //TODO: Add validations
        //TODO: Move errors to static factory class
        if (!Enum.TryParse<CurrencyCode>(request.Currency, out var currency))
            return new Error(400, "invalid.currency", $"The currency {request.Currency} is not supported.");

        var accountIdResult = await _sender.Send(new CreateBankAccountAccountCommand(request.Name, request.Number, currency));

        if (accountIdResult.IsFailed)
        {
            var reason = accountIdResult.Error;
            return new Error(reason!.StatusCode, "create.account.failed", "An error has occured while creating account", reason);
        }

        var bankAccount = new BankAccount
            (
                accountIdResult.Value,
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
