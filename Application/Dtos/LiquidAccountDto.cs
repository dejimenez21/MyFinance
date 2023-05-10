namespace Application.Dtos;

public class LiquidAccountDto
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string? BankCode { get; set; }
    public string? Network { get; set; }
    public string Alias { get; set; } = string.Empty;
    public string Group { get; set; } = string.Empty;
}
