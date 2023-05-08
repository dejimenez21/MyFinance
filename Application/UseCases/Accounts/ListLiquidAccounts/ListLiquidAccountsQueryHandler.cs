using Application.Dtos;
using AutoMapper;
using Domain.Abstractions;
using MediatR;

namespace Application.UseCases.Accounts.ListLiquidAccounts
{
    internal class ListLiquidAccountsQueryHandler : IRequestHandler<ListLiquidAccountsQuery, List<LiquidAccountDto>>
    {
        private readonly IAccountsRepository _accountRepository;
        private readonly IBankAccountsRepository _bankAccountsRepository;
        private readonly ICreditCardsRepository _creditCardsRepository;
        private readonly IMapper _mapper;

        public ListLiquidAccountsQueryHandler(
            IAccountsRepository accountRepository,
            IBankAccountsRepository bankAccountsRepository,
            ICreditCardsRepository creditCardsRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _bankAccountsRepository = bankAccountsRepository;
            _creditCardsRepository = creditCardsRepository;
            _mapper = mapper;
        }
          
        public async Task<List<LiquidAccountDto>> Handle(ListLiquidAccountsQuery request, CancellationToken cancellationToken)
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
