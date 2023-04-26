using SharedKernel.Domain.Primitives;

namespace Domain.Enums;

public class OperationType : Enumeration
{
    public static OperationType Credit = new OperationType("Credit");
    public static OperationType Debit = new OperationType("Debit");

    private OperationType(string name) : base(name) { }
}
