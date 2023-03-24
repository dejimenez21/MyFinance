using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
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
            private readonly IAccountRepository _accountRepository;
            private readonly IBankAccountsRepository _bankAccountsRepository;
            private readonly ICreditCardsRepository _creditCardsRepository;
            private readonly ILogger<GetLiquidAccountsSummary> _logger;
            private readonly IMapper _mapper;

            public Handler(IAccountRepository accountRepository, IBankAccountsRepository bankAccountsRepository, ICreditCardsRepository creditCardsRepository, ILogger<GetLiquidAccountsSummary> logger, IMapper mapper)
            {
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

                if(request.OnlyPaymentElegible)
                {
                    cashAccounts = cashAccounts.Where(a => a.IsElegibleForPayment).ToList();
                    bankAccounts = bankAccounts.Where(a => a.IsElegibleForPayment).ToList();
                    creditCardAccounts.Where(a => a.IsElegibleForPayment).ToList();
                }

                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(cashAccounts));
                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(bankAccounts));
                liquidAccounts.AddRange(_mapper.Map<List<LiquidAccountDto>>(creditCardAccounts));

                return liquidAccounts;
            }
        }
    }
}
