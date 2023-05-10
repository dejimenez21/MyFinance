using AutoMapper;
using SharedKernel.Domain.ValueObjects;

namespace Application.MappingProfiles;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<Enum, string>()
            .ConvertUsing(e => e.ToString());

        CreateMap<Money, decimal>()
            .ConvertUsing(m => m.Value);
    }
}
