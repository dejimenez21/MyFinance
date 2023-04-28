using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using Domain.Services.AccountBalance;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.Accounts
{
    public class GetLiquidAccountsSummary
    {
        public class Query : IRequest<List<LiquidAccountDto>>
        {
            public bool OnlyPaymentElegible { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<LiquidAccountDto>>
        {
            private readonly IAccountBalanceService _accountBalanceService;
            private readonly IAccountsRepository _accountRepository;
            private readonly IBankAccountsRepository _bankAccountsRepository;
            private readonly ICreditCardsRepository _creditCardsRepository;
            private readonly ILogger<GetLiquidAccountsSummary> _logger;
            private readonly IMapper _mapper;

            public Handler(IAccountBalanceService accountBalanceService, IAccountsRepository accountRepository, IBankAccountsRepository bankAccountsRepository, ICreditCardsRepository creditCardsRepository, ILogger<GetLiquidAccountsSummary> logger, IMapper mapper)
            {
                _accountBalanceService = accountBalanceService;
                _accountRepository = accountRepository;
                _bankAccountsRepository = bankAccountsRepository;
                _creditCardsRepository = creditCardsRepository;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<List<LiquidAccountDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var liquidAccounts = new List<LiquidAccountDto>();

                var cashAccounts = await _accountRepository.GetCashAccounts();
                var bankAccounts = await _bankAccountsRepository.GetAllAsync();
                var creditCardAccounts = await _creditCardsRepository.GetAllAsync();

                if (request.OnlyPaymentElegible)
                {
                    cashAccounts = cashAccounts.Where(a => a.IsElegibleForPayment).ToList();
                    bankAccounts = bankAccounts.Where(a => a.IsElegibleForPayment).ToList();
                    creditCardAccounts = creditCardAccounts.Where(a => a.IsElegibleForPayment).ToList();
                }

                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(cashAccounts));
                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(bankAccounts));
                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(creditCardAccounts));

                //var accountsIds = new List<Guid>();

                //accountsIds.AddRange(cashAccounts.Select(a => a.Id));
                //accountsIds.AddRange(bankAccounts.Select(a => a.Id));
                //accountsIds.AddRange(creditCardAccounts.Select(a => a.Id));

                //var accountBalances = await _accountBalanceService.GetAccountsBalances(accountsIds);

                //foreach (var liquidAccount in liquidAccounts)
                //{
                //    liquidAccount.Balance = accountBalances[liquidAccount.Id].Value;
                //}

                return liquidAccounts;
            }
        }
    }
}
