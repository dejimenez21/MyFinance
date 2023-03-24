using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BankAccount : Account
    {
        public BankCode Bank { get; protected set; }

        private BankAccount()
        {
            
        }

        public BankAccount(string name, string accountNumber, BankCode bankCode)
        {
            Name = name;
            Number = accountNumber;
            Bank = bankCode;
        }
    }
}
