using System;

namespace Scott.Dates.Recurring
{
    public interface IRuleInterval
    {
        IRuleFrequency Days();

        IRuleFrequency Weeks();

        IRuleFrequency Months();

        IRuleFrequency Years();
    }

    public interface IRuleFrequency
    {
        IRuleStart Starting(DateTime start);
    }

    public interface IRuleStart
    {
        IRuleEnd Ending(DateTime end);
    }

    public interface IRuleEnd
    {
        IRuleMonths In(Month month);

        IRuleDays OnMonths(Month month);
        IRuleDays OnMonth(DateTime date);

        IRuleDays On(Day day);

        IRuleDays OnDay(int day);

        IRuleDays OnDay(DayOfWeek day);

        IRuleDays OnOrdinalWeek(MonthWeek week);

        Rule Build();
    }

    public interface IRuleMonths
    {
        IRuleDays On(Day day);

        Rule Build();
    }

    public interface IRuleDays
    {
        IRuleMonths In(Month month);

        IRuleDays OnMonth(DateTime date);

        IRuleDays On(Day day);

        IRuleDays OnDay(int day);

        IRuleDays OnDay(DayOfWeek day);

        IRuleDays OnOrdinalWeek(MonthWeek week);

        Rule Build();
    }
}