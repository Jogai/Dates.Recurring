using System;
using System.Collections.Generic;
using System.Linq;

namespace Scott.Dates.Recurring
{
    public class BuilderFactory
    {
        public IRecurrenceBuilder GetBuilder(Freq frequency)
        {
            switch (frequency)
            {
                case Freq.Daily:
                    return new DailyBuilder();
                case Freq.Weekly:
                    return new WeeklyBuilder();
                case Freq.Monthly:
                    return new MonthlyBuilder();
                case Freq.Yearly:
                    return new YearlyBuilder();
            }
            return null;
        }
    }
}