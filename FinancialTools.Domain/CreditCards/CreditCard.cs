using FinancialTools.Domain.Common;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.CreditCards;

public class CreditCard : AggregateRoot
{
    private HashSet<CreditCardAccount> _accounts;

    public string Name { get; set; }
    public BankCode Bank { get; set; }
    public DateTime OpenedDate { get; set; }
    public CardDetails CardInfo { get; set; }
    public CreditCardStatementDate StatementDate { get; set; }

    public IReadOnlyCollection<CreditCardAccount> Accounts => _accounts;

    public CreditCard(string name, CardDetails cardInfo, ICollection<CreditCardAccount> accounts)
    {
        Id = Guid.NewGuid();
        Name = name;
        CardInfo = cardInfo;
        _accounts = accounts.ToHashSet(); ;
    }

}
