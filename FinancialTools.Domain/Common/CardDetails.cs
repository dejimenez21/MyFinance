using FinancialTools.Domain.Common.ValueObjects;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.Common;

public record CardDetails(string CardHolder, string Number, string CVV, PaymentNetwork Network, CardExpirationDate ExpirationDate) : ValueObject;
