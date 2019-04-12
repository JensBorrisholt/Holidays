using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Anguilla : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.March, 2, "James Ronald Webster Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(WhitMonday, "Whit Monday");
            Add(Year, Month.May, 30, "Anguilla Day");

            //Monday after second Saturday in June
            var dt = NthDayInMonth(Number.Second, DayOfWeek.Saturday, Month.June, Year).AddDays(2);
            Add(dt, "Celebration of the Birthday of Her Majesty the Queen");

            dt = NthDayInMonth(Number.First, DayOfWeek.Monday, Month.August, Year);
            Add(dt, "August Monday"); //First Monday of August
            Add(dt.AddDays(3), "August Thursday"); //Thursday after first Monday of August

            Add(Year, Month.August, 10, "Constitution Day");
            Add(Year, Month.December, 19, "National Heroes and Heroines Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }

    }
}

