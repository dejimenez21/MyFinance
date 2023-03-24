using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class LiquidAccountDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string? BankCode { get; set; }
        public string? Network { get; set; }
        public string Alias { get; set; }
        public string Group { get; set; }
    }
}
