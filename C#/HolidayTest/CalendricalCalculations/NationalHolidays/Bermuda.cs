using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Bermuda : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(GoodFriday, "Good Friday");
            Add(Number.Last, DayOfWeek.Friday, Month.May, Year, "Bermuda Day");
            Add(Number.Third, DayOfWeek.Monday, Month.June, Year, "National Heroes Day");

            var dt = NthDayInMonth(Number.First, DayOfWeek.Monday, Month.May, Year).AddDays(-4);
            Add(dt, "Emancipation Day"); //Thursday before the first Monday of August

            dt = dt.AddDays(1);
            Add(dt, "Somers' Day"); //Friday before the first Monday of August

            Add(Number.First, DayOfWeek.Monday,Month.September, Year, "Labour Day");
            Add(Year, Month.November, 4, "Marks the arrival of the first Portuguese immigrants");

            dt = new DateTime(Year, (int)Month.November, 11);

            if (dt.DayOfWeek == DayOfWeek.Saturday)
                dt = dt.AddDays(-1);
            else if(dt.DayOfWeek == DayOfWeek.Sunday)
                dt = dt.AddDays(1);
            Add(dt, "Remembrance Day"); //Weekday nearest November 11

            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

/*
  Notes
    * If a holiday falls on a weekend, the following Monday will be observed as a public holiday
*/
