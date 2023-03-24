using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.MappingProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, LiquidAccountDto>()
                .IncludeAllDerived()
                .ForMember(
                    l => l.Alias,
                    config => config.MapFrom(a => a.Name))
                .ForMember(
                    l => l.Group,
                    config => config.MapFrom(a => a.IsCash ? LiquidityGroup.CASH : LiquidityGroup.OTHER));
                

            CreateMap<CreditCard, LiquidAccountDto>()
                .ForMember(
                    d => d.BankCode, o => o.MapFrom(s => s.Bank.ToString()))
                .ForMember(l => l.Group, o => o.MapFrom(_ => LiquidityGroup.CREDIT_CARDS));

            CreateMap<BankAccount, LiquidAccountDto>()
                .ForMember(
                    d => d.BankCode, o => o.MapFrom(s => s.Bank.ToString()))
                .ForMember(l => l.Group, o => o.MapFrom(_ => LiquidityGroup.BANK_ACCOUNTS));
        }

    }

    public static class LiquidityGroup
    {
        public const string CASH = "Cash";
        public const string BANK_ACCOUNTS = "Bank Accounts";
        public const string CREDIT_CARDS = "Credit Cards";
        public const string OTHER = "Other";
    }
}
