using MediatR;

namespace FinancialTools.Application.UseCases.FinancialTools.List;

public record ListFinancialToolsQuery : IRequest<ListFinancialToolsQueryResponse>
{
}
