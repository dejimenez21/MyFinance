using MediatR;

namespace FinancialTools.Application.UseCases.FinancialTools.List;

internal class ListFinancialToolsQueryHandler : IRequestHandler<ListFinancialToolsQuery, ListFinancialToolsQueryResponse>
{
    public Task<ListFinancialToolsQueryResponse> Handle(ListFinancialToolsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
