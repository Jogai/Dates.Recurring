using Scott.Dates.Recurring;
using System;
using NUnit.Framework;

/*Taken inspiration for tests from gavynriebau/Dates.Recurring */

namespace Scott.Dates.Recurring.Tests
{
    public class WeeklyRecurrenceTests
    {
        [Test]
        public void WeeklyStartSunday()
        {
            var weekly = RuleBuilder
                .Every(2)
                .Weeks()
                .Starting(new DateTime(2016, 10, 2))
                .Ending(new DateTime(2016, 10, 31))
                .Build();
            Assert.AreEqual(16, weekly.Sequence.Count);
            Assert.AreEqual(new DateTime(2016, 10, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2016, 10, 5), weekly.Next(new DateTime(2016, 10, 4)));
            Assert.AreEqual(new DateTime(2016, 10, 16), weekly.Next(new DateTime(2016, 10, 8)));
        }

        [Test]
        public void WeeklyStartSaturday()
        {
            var weekly = RuleBuilder
                .Every(2)
                .Weeks()
                .Starting(new DateTime(2016, 10, 1))
                .Ending(new DateTime(2016, 10, 31))
                .Build();
            Assert.AreEqual(15, weekly.Sequence.Count);
            Assert.AreEqual(new DateTime(2016, 10, 1), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2016, 10, 9), weekly.Next(new DateTime(2016, 10, 1)));
        }

        [Test]
        public void Weekly_EveryWeek()
        {
            // Arrange.
            var weekly = RuleBuilder
                .Every(Freq.Weekly)
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2015, 2, 19))
                .On(Day.Tuesday | Day.Friday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 6), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.AreEqual(new DateTime(2015, 1, 9), weekly.Next(new DateTime(2015, 1, 6)));
            Assert.AreEqual(new DateTime(2015, 1, 13), weekly.Next(new DateTime(2015, 1, 9)));
            Assert.AreEqual(new DateTime(2015, 1, 16), weekly.Next(new DateTime(2015, 1, 13)));
        }

        [Test]
        public void Weekly_EveryThirdWeek()
        {
            // Arrange.
            var weekly = RuleBuilder
                .Every(3)
                .Weeks()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2015, 2, 19))
                .On(Day.Tuesday | Day.Friday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 2), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 20), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.AreEqual(new DateTime(2015, 1, 23), weekly.Next(new DateTime(2015, 1, 21)));
            Assert.AreEqual(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 23)));
            Assert.AreEqual(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 10), weekly.Next(new DateTime(2015, 1, 27)));
            Assert.AreEqual(new DateTime(2015, 2, 13), weekly.Next(new DateTime(2015, 2, 10)));
        }

        [Test]
        public void Weekly_EveryWeek_TwoDaysAfterDateTime()
        {
            // Arrange.
            var weekly = RuleBuilder
                .Every(Freq.Weekly)
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2015, 2, 19))
                .On(Day.Saturday)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 3), weekly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 3), weekly.Next(new DateTime(2015, 1, 2)));
            Assert.AreEqual(new DateTime(2015, 1, 10), weekly.Next(new DateTime(2015, 1, 6)));
            Assert.AreEqual(new DateTime(2015, 1, 10), weekly.Next(new DateTime(2015, 1, 9)));
            Assert.AreEqual(new DateTime(2015, 1, 17), weekly.Next(new DateTime(2015, 1, 13)));
            Assert.IsNull(weekly.Next(new DateTime(2015, 2, 19)));
        }
    }
}