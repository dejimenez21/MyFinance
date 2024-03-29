﻿using MediatR;
using SharedKernel.Common;
using SharedKernel.Domain.ValueObjects;

namespace SharedKernel.Application.Commands.Transactions;

public sealed record CreateExpenseTransactionCommand(string Description, DateTime Date, Money Amount, Guid PaymentAccountId, Guid? ExpenseAccountId)
    : IRequest<Result<Guid>>;

