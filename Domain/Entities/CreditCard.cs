using Application.Domain.Enums;
using Domain.Enums;
using SharedKernel.Domain.Enums;

namespace Domain.Entities
{
    public class CreditCard : Account
    {
        public BankCode Bank { get; protected set; }
        public PaymentNetwork Network { get; protected set; }

        private CreditCard()
        {
            
        }

        public CreditCard(string name, BankCode bank, string cardNumber, PaymentNetwork network, CurrencyCode currency, DateTime openedDate) : base(name, AccountType.Liability, cardNumber, currency, openedDate, 0)
        {
            Bank = bank;
            Network = network;
        }
    }
}
