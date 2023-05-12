using Application.Domain.Enums;
using SharedKernel.Domain.Enums;

namespace Domain.Entities
{
    public class CreditCard : Account
    {
        public BankCode Bank { get; protected set; }
        public PaymentNetwork Network { get; protected set; }
        public decimal CreditLimit { get; set; }
        public int StatementDay { get; set; }
        public int PaymentDueDateOffset { get; set; }
        public DateTime ExpirationDate { get; set; }

        private CreditCard()
        {
            
        }

        public CreditCard(string name, BankCode bank, string cardNumber, PaymentNetwork network, CurrencyCode currency, DateTime openedDate, DateTime now, decimal creditLimit) : base(name, AccountType.Liability, cardNumber, currency, openedDate, 0, now)
        {
            Bank = bank;
            Network = network;
        }
    }
}
