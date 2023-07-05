using Application.Domain.Enums;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using SharedKernel.Common;
using Transactions.Integration.Commands;

namespace Application.ModuleSync.Accounts
{
    internal class CreateBankAccountAccountCommandHanlder : IRequestHandler<CreateBankAccountAccountCommand, Result<Guid>>
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMapper _mapper;

        public CreateBankAccountAccountCommandHanlder(IAccountsRepository accountsRepository, IMapper mapper)
        {
            _accountsRepository = accountsRepository;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateBankAccountAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.Name, AccountType.Asset, request.Number, request.Currency);

            _accountsRepository.Insert(account);
            await _accountsRepository.SaveChangesAsync();

            return account.Id;
        }
    }
}
