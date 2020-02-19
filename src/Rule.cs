using System;
using System.Collections.Generic;
using System.Linq;

namespace Scott.Dates.Recurring
{
    public class Rule
    {
        public Freq Frequency;

        public DateTime Start;

        public DateTime Until;

        public int Interval;

        public Day Days;

        public Month Months;

        public List<DateTime> Sequence;

        public IEnumerable<int> MonthDays;

        public MonthWeek Week;

        public DateTime? Next(DateTime dateTime)
        {
            if (Sequence.Any(s => s > dateTime))
            {
                return Sequence.First(dt => dt > dateTime);
            }
            return null;
        }

        public DateTime? Previous(DateTime dateTime)
        {
            if (Sequence.Any(s => s < dateTime))
            {
                return Sequence.Last(dt => dt < dateTime);
            }
            return null;
        }
    }
}