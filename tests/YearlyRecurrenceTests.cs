using System;
using NUnit.Framework;

/*Taken inspiration for tests from gavynriebau/Dates.Recurring */

namespace Scott.Dates.Recurring.Tests
{
    public class YearlyRecurrenceTests
    {
        [Test]
        public void Yearly_EveryYear()
        {
            // Arrange.
            var yearly = RuleBuilder
                .Every(1)
                .Years()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2020, 1, 1))
                .OnMonths(Month.January | Month.February | Month.August)
                .OnDay(24)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 23)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.AreEqual(new DateTime(2016, 1, 24), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.AreEqual(new DateTime(2016, 2, 24), yearly.Next(new DateTime(2016, 1, 24)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 23)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 2, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 4, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 7, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 8, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 9, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 12, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2016, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2016, 1, 24)));
            Assert.AreEqual(new DateTime(2016, 1, 24), yearly.Previous(new DateTime(2016, 1, 25)));
            Assert.AreEqual(new DateTime(2016, 2, 24), yearly.Previous(new DateTime(2016, 2, 25)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 24)));
            Assert.Null(yearly.Previous(new DateTime(2015, 1, 1)));
            Assert.Null(yearly.Previous(new DateTime(2014, 1, 24)));
        }

        [Test]
        public void Yearly_EveryThirdYear()
        {
            // Arrange.
            var yearly = RuleBuilder
                .Every(3)
                .Years()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2020, 1, 1))
                .OnMonths(Month.January | Month.February | Month.August)
                .OnDay(24)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Next(new DateTime(2015, 2, 23)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 4, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 5, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 6, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Next(new DateTime(2015, 7, 24)));
            Assert.AreEqual(new DateTime(2018, 1, 24), yearly.Next(new DateTime(2015, 8, 24)));
            Assert.AreEqual(new DateTime(2018, 2, 24), yearly.Next(new DateTime(2018, 1, 24)));
            Assert.AreEqual(new DateTime(2018, 8, 24), yearly.Next(new DateTime(2018, 2, 24)));
            Assert.AreEqual(new DateTime(2018, 8, 24), yearly.Next(new DateTime(2018, 6, 11)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 1, 25)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 23)));
            Assert.AreEqual(new DateTime(2015, 1, 24), yearly.Previous(new DateTime(2015, 2, 24)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 2, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 8, 23)));
            Assert.AreEqual(new DateTime(2015, 2, 24), yearly.Previous(new DateTime(2015, 8, 24)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 8, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 9, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2016, 8, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2017, 8, 25)));
            Assert.AreEqual(new DateTime(2015, 8, 24), yearly.Previous(new DateTime(2018, 1, 24)));
            Assert.AreEqual(new DateTime(2018, 1, 24), yearly.Previous(new DateTime(2018, 1, 25)));
            Assert.AreEqual(new DateTime(2018, 2, 24), yearly.Previous(new DateTime(2018, 2, 25)));
            Assert.AreEqual(new DateTime(2018, 8, 24), yearly.Previous(new DateTime(2018, 8, 25)));
            Assert.AreEqual(new DateTime(2018, 8, 24), yearly.Previous(new DateTime(2020, 8, 25)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 24)));
        }

        [Test]
        public void Yearly_EveryYear_DifferentDaysInMonth()
        {
            // Arrange.
            var yearly = RuleBuilder
                .Every(1)
                .Years()
                .Starting(new DateTime(2015, 1, 1))
                .Ending(new DateTime(2020, 1, 1))
                .OnMonths(Month.January | Month.February | Month.August)
                .OnDay(31)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 1, 31), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 31), yearly.Next(new DateTime(2015, 1, 6)));
            Assert.AreNotEqual(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 1, 31)));
            Assert.AreNotEqual(new DateTime(2015, 2, 28), yearly.Next(new DateTime(2015, 2, 27)));
            Assert.AreEqual(new DateTime(2015, 8, 31), yearly.Next(new DateTime(2015, 2, 28)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.AreEqual(new DateTime(2015, 1, 31), yearly.Previous(new DateTime(2015, 2, 1)));
            Assert.AreEqual(new DateTime(2015, 1, 31), yearly.Previous(new DateTime(2015, 2, 28)));
            Assert.AreNotEqual(new DateTime(2015, 2, 28), yearly.Previous(new DateTime(2015, 3, 1)));
            Assert.AreNotEqual(new DateTime(2015, 2, 28), yearly.Previous(new DateTime(2015, 3, 1)));
            Assert.AreEqual(new DateTime(2015, 8, 31), yearly.Previous(new DateTime(2015, 9, 1)));

            Assert.Null(yearly.Previous(new DateTime(2015, 1, 31)));
        }

        [Test]
        public void Yearly_EveryYear_TwoMonthsAfterDateTime()
        {
            // Arrange.
            var startDate = new DateTime(2015, 1, 1);

            var yearly = RuleBuilder
                .Every(1)
                .Years()
                .Starting(startDate)
                .Ending(new DateTime(2020, 1, 1))
                .OnMonth(startDate.AddMonths(2))
                .OnDay(24)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2015, 1, 1)));
            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Next(new DateTime(2015, 1, 23)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 3, 24)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 3, 25)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 1)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 23)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Next(new DateTime(2015, 10, 24)));
            Assert.AreEqual(new DateTime(2017, 3, 24), yearly.Next(new DateTime(2016, 3, 24)));
            Assert.AreEqual(new DateTime(2017, 3, 24), yearly.Next(new DateTime(2016, 4, 24)));

            Assert.Null(yearly.Next(new DateTime(2020, 1, 1)));

            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2015, 3, 25)));
            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2015, 10, 25)));
            Assert.AreEqual(new DateTime(2015, 3, 24), yearly.Previous(new DateTime(2016, 3, 24)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Previous(new DateTime(2016, 3, 25)));
            Assert.AreEqual(new DateTime(2016, 3, 24), yearly.Previous(new DateTime(2017, 3, 24)));
            Assert.AreEqual(new DateTime(2017, 3, 24), yearly.Previous(new DateTime(2017, 3, 25)));
            Assert.AreEqual(new DateTime(2017, 3, 24), yearly.Previous(new DateTime(2018, 3, 24)));

            Assert.Null(yearly.Previous(new DateTime(2015, 3, 24)));
        }

        [Test]
        public void Yearly_EveryYear_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            var yearly = RuleBuilder
                .Every(1)
                .Years()
                .Starting(startDate)
                .Ending(new DateTime(2030, 1, 1))
                .OnOrdinalWeek(MonthWeek.Third)
                .OnDay(DayOfWeek.Thursday)
                .In(Month.January)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2019, 1, 17), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.AreEqual(new DateTime(2020, 1, 16), yearly.Next(new DateTime(2019, 2, 18)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2019, 1, 17)));
            Assert.AreEqual(new DateTime(2019, 1, 17), yearly.Previous(new DateTime(2019, 1, 18)));
            Assert.AreEqual(new DateTime(2020, 1, 16), yearly.Previous(new DateTime(2020, 1, 17)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }

        [Test]
        public void Yearly_EveryThirdYear_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            var yearly = RuleBuilder
                .Every(3)
                .Years()
                .Starting(startDate)
                .Ending(new DateTime(2030, 1, 1))
                .OnOrdinalWeek(MonthWeek.Third)
                .OnDay(DayOfWeek.Thursday)
                .In(Month.January)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2021, 1, 21), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.AreEqual(new DateTime(2024, 1, 18), yearly.Next(new DateTime(2021, 2, 18)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2021, 1, 21)));
            Assert.AreEqual(new DateTime(2021, 1, 21), yearly.Previous(new DateTime(2021, 1, 22)));
            Assert.AreEqual(new DateTime(2024, 1, 18), yearly.Previous(new DateTime(2024, 1, 19)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }

        [Test]
        public void Yearly_MultipleMonths_Ordinal()
        {
            // Arrange.
            var startDate = new DateTime(2018, 1, 1);

            var yearly = RuleBuilder
                .Every(1)
                .Years()
                .Starting(startDate)
                .Ending(new DateTime(2030, 1, 1))
                .OnOrdinalWeek(MonthWeek.Third)
                .OnDay(DayOfWeek.Thursday)
                .In(Month.January | Month.April)
                .Build();

            // Act.

            // Assert.
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2014, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Next(new DateTime(2018, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 4, 19), yearly.Next(new DateTime(2018, 1, 18)));
            Assert.AreEqual(new DateTime(2019, 1, 17), yearly.Next(new DateTime(2018, 4, 19)));

            Assert.Null(yearly.Next(new DateTime(2030, 1, 1)));

            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 1, 19)));
            Assert.AreEqual(new DateTime(2018, 1, 18), yearly.Previous(new DateTime(2018, 4, 19)));
            Assert.AreEqual(new DateTime(2018, 4, 19), yearly.Previous(new DateTime(2018, 4, 20)));
            Assert.AreEqual(new DateTime(2019, 1, 17), yearly.Previous(new DateTime(2019, 1, 18)));

            Assert.Null(yearly.Previous(new DateTime(2018, 1, 18)));
        }
    }
}