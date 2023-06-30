using FinancialTools.Domain.BankAccounts;
using MediatR;
using SharedKernel.Common;

namespace FinancialTools.Application.UseCases.BankAccounts.Create;

public record CreateBankAccountCommand
(
    string Name,
    string Number,
    string Bank,
    string Currency,
    string Type,
    DateTime OpenedDate
) : IRequest<Result<BankAccount>> { }