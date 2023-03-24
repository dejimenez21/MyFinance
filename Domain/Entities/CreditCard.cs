using Application.Domain.Enums;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CreditCard : Account
    {
        public BankCode Bank { get; protected set; }
        public PaymentNetwork Network { get; protected set; }

        private CreditCard()
        {
            
        }

        public CreditCard(string name, BankCode bank, string cardNumber, PaymentNetwork network)
        {
            Name = name;
            Bank = bank;
            Number = cardNumber;
            Network = network;
        }
    }
}
