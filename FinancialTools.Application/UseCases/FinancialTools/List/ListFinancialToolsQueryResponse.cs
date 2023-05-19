namespace FinancialTools.Application.UseCases.FinancialTools.List;

public record ListFinancialToolsQueryResponse(
    Guid Id,
    string Number,
    decimal Balance,
    string Currency,
    string? BankCode,
    string? Network,
    string Alias,
    string Group);