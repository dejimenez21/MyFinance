using FinancialTools.Domain.Common.ValueObjects;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.Common;

public record CardDetails : ValueObject
{
    public string CardHolder { get; private set; }
    public string Number { get; private set; }
    public string CVV { get; private set; }
    public PaymentNetwork Network { get; private set; }
    public CardExpirationDate ExpirationDate { get; private set; }

    public CardDetails(string cardHolder, string number, string cVV, PaymentNetwork network, CardExpirationDate expirationDate)
    {
        CardHolder = cardHolder;
        Number = number;
        CVV = cVV;
        Network = network;
        ExpirationDate = expirationDate;
    }

    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CardDetails() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}
