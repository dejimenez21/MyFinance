﻿using Domain.Entities;
using SharedKernel.Domain.Abstractions;

namespace Domain.Abstractions
{
    public interface IAccountMovementsRepository : IRepository<AccountEntry>
    {
        Task<IEnumerable<AccountEntry>> GetMovementsByAccountId(Guid accountId);
        Task<IEnumerable<AccountEntry>> GetMovementsByMultipleAccountIds(IEnumerable<Guid> accountIds);
    }
}
