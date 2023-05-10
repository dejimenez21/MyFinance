namespace SharedKernel.Infrastructure;

public class DateTimes : IDateTimes
{
    public DateTime Now()
    {
        return DateTime.Now;
    }
}
