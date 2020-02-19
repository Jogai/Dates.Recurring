using System;

namespace Scott.Dates.Recurring
{
    public enum Freq
    {
        Daily,
        Weekly,
        Monthly,
        Yearly
    }

    [Flags]
    public enum Day
    {
        Sunday = 1 << DayOfWeek.Sunday,
        Monday = 1 << DayOfWeek.Monday,
        Tuesday = 1 << DayOfWeek.Tuesday,
        Wednesday = 1 << DayOfWeek.Wednesday,
        Thursday = 1 << DayOfWeek.Thursday,
        Friday = 1 << DayOfWeek.Friday,
        Saturday = 1 << DayOfWeek.Saturday
    }

    [Flags]
    public enum Month
    {
        January = 1 << 0,
        February = 1 << 1,
        March = 1 << 2,
        April = 1 << 3,
        May = 1 << 4,
        June = 1 << 5,
        July = 1 << 6,
        August = 1 << 7,
        September = 1 << 8,
        October = 1 << 9,
        November = 1 << 10,
        December = 1 << 11
    }

    public enum MonthWeek
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5,
    }
}