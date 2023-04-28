using AutoMapper;
using Expenses.Domain.Expenses;

namespace Expenses.Application.MappingProfiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Enum, string>()
                .ConvertUsing(e => e.ToString());

            CreateMap<string, ExpenseCategory>()
                .ConvertUsing(s => Enum.Parse<ExpenseCategory>(s));
        }
    }
}
