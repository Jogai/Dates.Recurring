using System;
using NUnit.Framework;

/*Taken inspiration for tests from gavynriebau/Dates.Recurring */

namespace Scott.Dates.Recurring.Tests
{
    public class MonthlyRecurrenceTests
    {
        [Test]
        public void Monthly_EveryMonth()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(1)
                .Months()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2016, 2, 4))
                .OnDay(24)
                .Build();

            Assert.AreEqual(new DateTime(2015, 1, 24), monthly.Next(new DateTime(2014, 4, 8)));
            Assert.AreEqual(new DateTime(2015, 2, 24), monthly.Next(new DateTime(2015, 1, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), monthly.Next(new DateTime(2015, 2, 23)));
            Assert.AreEqual(new DateTime(2015, 3, 24), monthly.Next(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 3, 24), monthly.Next(new DateTime(2015, 2, 25)));
            Assert.AreEqual(new DateTime(2015, 6, 24), monthly.Next(new DateTime(2015, 6, 3)));

            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.AreEqual(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 2, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 3, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), monthly.Previous(new DateTime(2015, 2, 25)));
            Assert.AreEqual(new DateTime(2015, 3, 24), monthly.Previous(new DateTime(2015, 3, 25)));
            Assert.AreEqual(new DateTime(2015, 3, 24), monthly.Previous(new DateTime(2015, 4, 24)));
            Assert.AreEqual(new DateTime(2015, 6, 24), monthly.Previous(new DateTime(2015, 6, 25)));

            Assert.Null(monthly.Previous(new DateTime(2015, 1, 24)));
        }

        [Test]
        public void Monthly_EveryThirdMonth()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(3)
                .Months()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2016, 2, 4))
                .OnDay(24)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 24), monthly.Next(new DateTime(2014, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 1, 24)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 2, 17)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Next(new DateTime(2015, 4, 23)));
            Assert.AreEqual(new DateTime(2015, 7, 24), monthly.Next(new DateTime(2015, 4, 24)));

            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.AreEqual(new DateTime(2015, 1, 24), monthly.Previous(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 4, 25)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 5, 25)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 6, 25)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 7, 23)));
            Assert.AreEqual(new DateTime(2015, 4, 24), monthly.Previous(new DateTime(2015, 7, 24)));
            Assert.AreEqual(new DateTime(2015, 7, 24), monthly.Previous(new DateTime(2015, 7, 25)));

            Assert.Null(monthly.Previous(new DateTime(2015, 1, 24)));
        }

        [Test]
        public void Monthly_EveryMonth_DifferentDaysInMonths()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(1)
                .Months()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2016, 2, 4))
                .OnDay(31)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 31), monthly.Next(new DateTime(2014, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 31), monthly.Next(new DateTime(2015, 1, 30)));
            Assert.AreEqual(new DateTime(2015, 3, 31), monthly.Next(new DateTime(2015, 2, 28)));

            Assert.Null(monthly.Next(new DateTime(2016, 6, 3)));

            Assert.AreEqual(new DateTime(2015, 1, 31), monthly.Previous(new DateTime(2015, 2, 28)));
            Assert.AreEqual(new DateTime(2015, 1, 31), monthly.Previous(new DateTime(2015, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 3, 31), monthly.Previous(new DateTime(2015, 4, 1)));

            Assert.Null(monthly.Previous(new DateTime(2015, 1, 31)));
        }

        [Test]
        public void Monthly_EveryMonth_Ordinal()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(1)
                .Months()
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Ending(new DateTime(2018, 12, 25))
                .OnOrdinalWeek(MonthWeek.Second)
                .On(Day.Friday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 2, 9), monthly.Next(new DateTime(2018, 2, 1)));
            Assert.AreEqual(new DateTime(2018, 9, 14), monthly.Next(new DateTime(2018, 9, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 1, 13)));
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 2, 9)));
            Assert.AreEqual(new DateTime(2018, 2, 9), monthly.Previous(new DateTime(2018, 2, 10)));
            Assert.AreEqual(new DateTime(2018, 9, 14), monthly.Previous(new DateTime(2018, 9, 15)));

            Assert.Null(monthly.Previous(new DateTime(2018, 1, 12)));
        }

        [Test]
        public void Monthly_EveryThirdMonth_Ordinal()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(3)
                .Months()
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Ending(new DateTime(2018, 12, 25))
                .OnOrdinalWeek(MonthWeek.Second)
                .On(Day.Friday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 4, 13), monthly.Next(new DateTime(2018, 1, 12)));
            Assert.AreEqual(new DateTime(2018, 7, 13), monthly.Next(new DateTime(2018, 7, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 1, 13)));
            Assert.AreEqual(new DateTime(2018, 1, 12), monthly.Previous(new DateTime(2018, 4, 13)));
            Assert.AreEqual(new DateTime(2018, 4, 13), monthly.Previous(new DateTime(2018, 4, 14)));
            Assert.AreEqual(new DateTime(2018, 4, 13), monthly.Previous(new DateTime(2018, 7, 13)));

            Assert.Null(monthly.Previous(new DateTime(2018, 1, 12)));
        }

        [Test]
        public void Monthly_EveryMonth_Ordinal_LastWeek()
        {
            // Arrange.
            var monthly = RuleBuilder
                .Every(1)
                .Months()
                .Starting(new DateTime(2018, 1, 1)) // Monday
                .Ending(new DateTime(2018, 12, 25))
                .OnOrdinalWeek(MonthWeek.Last)
                .On(Day.Wednesday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 31), monthly.Next(new DateTime(2017, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 31), monthly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 2, 28), monthly.Next(new DateTime(2018, 1, 31)));
            Assert.AreEqual(new DateTime(2018, 2, 28), monthly.Next(new DateTime(2018, 2, 1)));
            Assert.AreEqual(new DateTime(2018, 4, 25), monthly.Next(new DateTime(2018, 4, 1)));

            Assert.Null(monthly.Next(new DateTime(2020, 2, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 31), monthly.Previous(new DateTime(2018, 2, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 31), monthly.Previous(new DateTime(2018, 2, 28)));
            Assert.AreEqual(new DateTime(2018, 2, 28), monthly.Previous(new DateTime(2018, 3, 1)));
            Assert.AreEqual(new DateTime(2018, 3, 28), monthly.Previous(new DateTime(2018, 4, 25)));
            Assert.AreEqual(new DateTime(2018, 4, 25), monthly.Previous(new DateTime(2018, 4, 26)));

            Assert.Null(monthly.Previous(new DateTime(2018, 1, 31)));
        }
    }
}