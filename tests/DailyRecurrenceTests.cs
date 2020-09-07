using Scott.Dates.Recurring;
using System;
using System.Linq;
using NUnit.Framework;

/*Taken inspiration for tests from gavynriebau/Dates.Recurring */

namespace Scott.Dates.Recurring.Tests
{
    public class DailyRecurrenceTests
    {
        [Test]
        public void Daily_EveryDay()
        {
            var daily = RuleBuilder
                .Every(Freq.Daily)
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2015, 1, 15))
                .Build();

            Assert.AreEqual(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.AreEqual(new DateTime(2015, 1, 2), daily.Next(new DateTime(2015, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 3), daily.Next(new DateTime(2015, 1, 2)));
            //Assert.IsNull(daily.Next(new DateTime(2015, 1, 15)));
        }

        [Test]
        public void Daily_Every7thDay()
        {
            var daily = RuleBuilder
                .Every(7)
                .Days()
                .Starting(new DateTime(2020, 9, 7))
                .Ending(new DateTime(2020, 9, 30))
                .Build();

            Assert.AreEqual(new DateTime(2020, 9, 7), daily.Sequence.First());
            Assert.AreEqual(new DateTime(2020, 9, 28), daily.Sequence.Last());
        }

        [Test]
        public void Daily_Every8thDay()
        {
            var daily = RuleBuilder
                .Every(8)
                .Days()
                .Starting(new DateTime(2020, 9, 5))
                .Ending(new DateTime(2020, 9, 30))
                .Build();

            Assert.AreEqual(new DateTime(2020, 9, 5), daily.Sequence.First());
            Assert.AreEqual(new DateTime(2020, 9, 29), daily.Sequence.Last());
            Assert.AreEqual(4, daily.Sequence.Count());
        }

        [Test]
        public void Daily_EveryThirdDay()
        {
            var daily = RuleBuilder
                .Every(3)
                .Days()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2015, 12, 12))
                .Build();

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 1), daily.Next(new DateTime(2014, 7, 3)));
            Assert.AreEqual(new DateTime(2015, 1, 4), daily.Next(new DateTime(2015, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 7), daily.Next(new DateTime(2015, 1, 5)));
        }

        [Test]
        public void ContinuousRules()
        {
            var p = RuleBuilder.Every(Freq.Daily)
                .Starting(new DateTime())
                .Ending(new DateTime().AddDays(1))
                .Build();
            Assert.AreEqual(2, p.Sequence.Count);
        }

        [Test]
        public void EveryOtherA()
        {
            var t = RuleBuilder.Every(2)
                .Days()
                .Starting(new DateTime(2017, 1, 1))
                .Ending(new DateTime(2017, 4, 30))
                .Build();
            Assert.AreEqual(60, t.Sequence.Count);
        }

        [Test]
        public void EveryOtherB()
        {
            var t = RuleBuilder.Every(2)
                .Days()
                .Starting(new DateTime(1985, 11, 3))
                .Ending(new DateTime(1986, 2, 1))
                .Build();
            Assert.AreEqual(46, t.Sequence.Count);
            Assert.AreEqual(new DateTime(1985, 12, 31), t.Sequence[29]);
        }

        [Test]
        public void EveryOtherIn()
        {
            var t = RuleBuilder.Every(2)
                .Days()
                .Starting(new DateTime(1985, 11, 3))
                .Ending(new DateTime(1986, 2, 1))
                .In(Month.January | Month.December)
                .Build();
            Assert.AreEqual(31, t.Sequence.Count);
            Assert.AreEqual(new DateTime(1985, 12, 31), t.Sequence[15]);
        }

        [Test]
        public void EveryOtherOn()
        {
            var t = RuleBuilder.Every(2)
                .Days()
                .Starting(new DateTime(1985, 11, 3))
                .Ending(new DateTime(1986, 2, 1))
                .On(Day.Tuesday | Day.Thursday)
                .Build();
            Assert.AreEqual(14, t.Sequence.Count);
            Assert.AreEqual(new DateTime(1985, 12, 31), t.Sequence[8]);
        }

        [Test]
        public void EveryOtherInOn()
        {
            var t = RuleBuilder.Every(2)
                .Days()
                .Starting(new DateTime(1985, 11, 3))
                .Ending(new DateTime(1986, 2, 1))
                .In(Month.January | Month.December)
                .On(Day.Tuesday | Day.Thursday)
                .Build();
            Assert.AreEqual(10, t.Sequence.Count);
            Assert.AreEqual(new DateTime(1985, 12, 31), t.Sequence[4]);
        }
    }
}