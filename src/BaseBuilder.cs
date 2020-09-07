using System;
using System.Collections.Generic;
using System.Linq;

namespace Scott.Dates.Recurring
{
    public interface IRecurrenceBuilder
    {
        Rule BuildRule(Rule _rule);
    }

    public class DailyBuilder : BaseBuilder, IRecurrenceBuilder
    {
        public Rule BuildRule(Rule rule)
        {
            var days = (rule.Until - rule.Start).Days + 1;
            //Divide days by the interval to know the number of occurences
            var occurrences = days / rule.Interval;
            if (days % rule.Interval > 0)
            {
                occurrences++;
            }
            //Generate all the days
            var daily = Enumerable.Range(0, occurrences)
            .Select(x => rule.Start.AddDays(x * rule.Interval))
            .Where(x => x <= rule.Until);
            //Apply filter for days or months
            if (rule.Days != 0 || rule.Months != 0)
            {
                rule.Sequence = CalculateSequence(rule, daily);
            }
            else
            {
                rule.Sequence = daily.ToList();
            }
            return rule;
        }
    }

    public class WeeklyBuilder : BaseBuilder, IRecurrenceBuilder
    {
        public Rule BuildRule(Rule rule)
        {
            var weekStart = rule.Start.AddDays(-1 * (int)rule.Start.DayOfWeek);
            var weekEnding = rule.Until.AddDays(7 - (int)rule.Until.DayOfWeek);
            var weeks = (weekEnding - weekStart).Days / 7;
            //Dates stretched to full weeks

            var weekly = Enumerable.Range(0, weeks)
                .Where(sd => sd % rule.Interval == 0)
                .SelectMany(week => Enumerable.Range(week * 7, 7))
                .Select(weekDays => weekStart.AddDays(weekDays))
                .Where(x => x >= rule.Start && x <= rule.Until);

            //Apply filter for days or months
            if (rule.Days != 0 || rule.Months != 0)
            {
                rule.Sequence = CalculateSequence(rule, weekly);
            }
            else
            {
                rule.Sequence = weekly.ToList();
            }
            return rule;
        }
    }

    public class MonthlyBuilder : BaseBuilder, IRecurrenceBuilder
    {
        public Rule BuildRule(Rule rule)
        {
            var monthly = Enumerable.Range(rule.Start.Year, 1 + rule.Until.Year - rule.Start.Year)
                            .SelectMany(_ => Enumerable.Range(1, 12), (year, month) => new DateTime(year, month, 1)) //All months
                            .Where(x => x >= new DateTime(rule.Start.Year, rule.Start.Month, 1) //From starting year & month
                                        && x <= rule.Until
                                        && (x.Month - rule.Start.Month) % rule.Interval == 0)
                            .SelectMany(x => (rule.MonthDays.Some() ? rule.MonthDays.Where(d => d <= DateTime.DaysInMonth(x.Year, x.Month)) : Enumerable.Range(1, DateTime.DaysInMonth(x.Year, x.Month))) //Valid days in month (either given days, or all days of month)
                            .Where(y => (rule.Week == 0 || rule.Week == MonthWeek.Last || (int)rule.Week == (((y - 1) / 7) + 1)) //Valid in given weeks
                            && (rule.Week != MonthWeek.Last || DateTime.DaysInMonth(x.Year, x.Month) - 7 < y)) //Valid in last week
                            , (monthDate, day) => new DateTime(monthDate.Year, monthDate.Month, day));
            //Apply filter for days or months
            rule.Sequence = CalculateSequence(rule, monthly);

            return rule;
        }
    }

    public class YearlyBuilder : BaseBuilder, IRecurrenceBuilder
    {
        public Rule BuildRule(Rule rule)
        {
            var dateTimes = Enumerable.Range(rule.Start.Year, 1 + rule.Until.Year - rule.Start.Year)
                            .SelectMany(_ => Enumerable.Range(1, 12), (year, month) => new DateTime(year, month, 1)) //All months
                            .Where(x => x <= rule.Until
                                        && (x.Year - rule.Start.Year) % rule.Interval == 0)
                            .SelectMany(x => (rule.MonthDays.Some() ? rule.MonthDays.Where(d => d <= DateTime.DaysInMonth(x.Year, x.Month)) : Enumerable.Range(1, DateTime.DaysInMonth(x.Year, x.Month))) //Valid days in month (either given days, or all days of month)
                            .Where(y => (rule.Week == 0 || rule.Week == MonthWeek.Last || (int)rule.Week == (((y - 1) / 7) + 1)) //Valid in given weeks
                            && (rule.Week != MonthWeek.Last || DateTime.DaysInMonth(x.Year, x.Month) - 7 < y)) //Valid in last week
                            , (monthDate, day) => new DateTime(monthDate.Year, monthDate.Month, day));
            //Apply filter for days or months
            rule.Sequence = CalculateSequence(rule, dateTimes);

            return rule;
        }
    }

    public static class Extensions
    {
        public static bool Some<T>(this IEnumerable<T> source)
        {
            return source?.Any() == true;
        }
    }

    public class BaseBuilder
    {
        protected List<DateTime> CalculateSequence(Rule rule, IEnumerable<DateTime> sequence)
        {
            if (rule.Days != 0)
                sequence = sequence.Where(x => ((1 << (int)x.DayOfWeek) & (int)rule.Days) != 0);

            if (rule.Months != 0)
                sequence = sequence.Where(x => ((1 << x.Month - 1) & (int)rule.Months) != 0);

            if (rule.MonthDays.Some())
                sequence = sequence.Where(x => rule.MonthDays.Contains(x.Day));

            return sequence.Where(s => s <= rule.Until).ToList();
        }
    }
}