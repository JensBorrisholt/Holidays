using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class AntiguaAndBarbuda : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.May, 4, "Labour Day");
            Add(WhitMonday, "Whit Monday");

            var dt = NthDayInMonth(Number.First, DayOfWeek.Monday, Month.August, Year);
            Add(dt, "J'Ouvert");

            Add(dt.AddDays(3), "Last Lap"); //Tuesday after first Monday in August
            Add(Year, Month.November, 1, "Independence Day");
            Add(Year, Month.November, 2, "Independence Day Holiday");
            Add(Year, Month.December, 9, "V.C. Bird Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }

    }
}

/*
  Notes
    * If January 1st falls on a Sunday, then the following Monday shall be a public holiday.
    * If Christmas Day falls on a Saturday, then the following Monday shall be a public holiday.
    * If Christmas Day falls on a Sunday, then the following Monday and Tuesday shall be public holidays.
    * Sundays, Christmas Day and Good Friday are observed as Common Law Holidays.
*/
