using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.CreditCards;

public record CreditCardStatementDate : ValueObject
{
    public int DayOfTheMonth { get; init; }
    public int PaymentDueDateDaysOffset { get; init; }

    public DateTime NextStatementDate(DateTime now)
    {
        var currentMonth = now.Month;
        var currentYear = now.Year;
        var currentDay = now.Day;

        var statementDateMonth = currentDay < DayOfTheMonth ? currentMonth : currentMonth + 1;
        var statementYear = statementDateMonth <= 12 ? currentYear : currentYear + 1;
        statementDateMonth = statementDateMonth <= 12 ? statementDateMonth : statementDateMonth % 12;

        var adjustedDayOfTheMonth = Math.Min(DayOfTheMonth, DateTime.DaysInMonth(statementYear, statementDateMonth));

        return new DateTime(statementYear, statementDateMonth, adjustedDayOfTheMonth);
    }

    public DateTime LastStatementDate(DateTime now)
    {
        var currentMonth = now.Month;
        var currentYear = now.Year;
        var currentDay = now.Day;

        var statementDateMonth = currentDay >= DayOfTheMonth ? currentMonth : currentMonth - 1;
        var statementYear = statementDateMonth >= 1 ? currentYear : currentYear - 1;
        statementDateMonth = statementDateMonth >= 1 ? statementDateMonth : 12;

        var adjustedDayOfTheMonth = Math.Min(DayOfTheMonth, DateTime.DaysInMonth(statementYear, statementDateMonth));

        return new DateTime(statementYear, statementDateMonth, adjustedDayOfTheMonth);
    }

    public DateTime PaymentDueDate(DateTime now) => LastStatementDate(now).AddDays(PaymentDueDateDaysOffset);
}
