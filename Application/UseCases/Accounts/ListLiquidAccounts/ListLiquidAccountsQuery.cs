using Application.Dtos;
using MediatR;

namespace Application.UseCases.Accounts.ListLiquidAccounts
{
    public record ListLiquidAccountsQuery : IRequest<List<LiquidAccountDto>>
    {
        public bool OnlyPaymentElegible { get; set; }
    }
}
