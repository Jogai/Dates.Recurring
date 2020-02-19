using System;
using System.Collections.Generic;

namespace Scott.Dates.Recurring
{
    public sealed class RuleBuilder : IRuleInterval, IRuleFrequency, IRuleStart, IRuleEnd, IRuleMonths, IRuleDays
    {
        private readonly Rule _rule;

        private RuleBuilder(Freq t)
        {
            _rule = new Rule { Frequency = t, Interval = 1 };
        }

        private RuleBuilder(int i)
        {
            _rule = new Rule { Interval = i };
        }

        public static IRuleFrequency Every(Freq freq)
        {
            return new RuleBuilder(freq);
        }

        public static IRuleInterval Every(int interval)
        {
            return new RuleBuilder(interval);
        }

        public IRuleFrequency Days()
        {
            _rule.Frequency = Freq.Daily;
            return this;
        }

        public IRuleFrequency Weeks()
        {
            _rule.Frequency = Freq.Weekly;
            return this;
        }

        public IRuleFrequency Months()
        {
            _rule.Frequency = Freq.Monthly;
            return this;
        }

        public IRuleFrequency Years()
        {
            _rule.Frequency = Freq.Yearly;
            return this;
        }

        public IRuleStart Starting(DateTime start)
        {
            _rule.Start = start;
            return this;
        }

        public IRuleEnd Ending(DateTime end)
        {
            _rule.Until = end;
            return this;
        }

        public IRuleMonths In(Month month)
        {
            _rule.Months = month;
            return this;
        }

        public IRuleDays OnMonths(Month month)
        {
            _rule.Months = month;
            return this;
        }

        public IRuleDays OnMonth(DateTime date)
        {
            _rule.Months = (Month)(1 << date.Month - 1);
            return this;
        }

        public IRuleDays On(Day day)
        {
            _rule.Days = day;
            return this;
        }

        public IRuleDays OnDay(int day)
        {
            _rule.MonthDays = new List<int> { day };
            return this;
        }

        public IRuleDays OnDay(DayOfWeek day)
        {
            _rule.Days = (Day)(1 << (int)day);
            return this;
        }

        public IRuleDays OnOrdinalWeek(MonthWeek week)
        {
            _rule.Week = week;
            return this;
        }

        public Rule Build()
        {
            var builder = new BuilderFactory().GetBuilder(_rule.Frequency);
            return builder.BuildRule(_rule);
        }
    }
}