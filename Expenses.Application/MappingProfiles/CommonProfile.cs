using AutoMapper;
using Expenses.Application.UseCases.Expenses.Create;
using Expenses.Domain.Expenses;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Expenses.Application.MappingProfiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Enum, string>()
                .ConvertUsing(e => e.ToString());

            CreateMap<string, ExpenseCategory>()
                .ConvertUsing(s => Enumeration.FromName<ExpenseCategory>(s));

            CreateMap<Money, MoneyDto>()
                .ForMember(d => d.Currency, opt => opt.MapFrom(e => e.ToString()));
        }
    }
}
