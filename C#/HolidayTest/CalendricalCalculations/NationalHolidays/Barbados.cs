using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Barbados : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.January, 21, "Errol Barrow Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.April, 28, "National Heroes Day");
            Add(LaborDay, "May Day");
            Add(WhitMonday, "Whit Monday");
            Add(Year, Month.August, 1, "Emancipation Day");
            Add(Number.First, DayOfWeek.Monday,Month.August, Year, "Kadooment Day");
            Add(Year, Month.November, 30, "Independence Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

/*
  Notes
    * If the date of a bank holiday falls on a Sunday, it is generally moved to the following day
*/
