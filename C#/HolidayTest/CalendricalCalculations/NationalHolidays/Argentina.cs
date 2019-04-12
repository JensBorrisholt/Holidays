using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Argentina : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(AshWdensday.AddDays(-2), "Carnival Monday");
            Add(AshWdensday.AddDays(-1), "Carnival Tuesday");
            Add(Year, Month.March, 24, "Truth and Justice Memorial Day");
            Add(Year, Month.April, 2, "Malvinas Day");
            Add(GoodFriday, "Good Friday");
            Add(LaborDay, "Labour Day");
            Add(Year, Month.May, 25, "May Day Revolution");
            if (Year >= 2016)
                Add(Year, Month.June, 17, "Martin Miguel de Guemes Day");

            Add(Year, Month.June, 20, "National Flag Day");
            Add(Year, Month.July, 9, "Independence Day");

            Add(Number.Third, DayOfWeek.Monday, Month.August, Year, "St. Martin's Day");
            Add(Year, Month.October, 12, "Day of respect for cultural diversity");
            Add(Number.Fourth, DayOfWeek.Monday, Month.November, Year, "Day of National Sovereignty");

            Add(Year, Month.December, 7, "Public Holiday");
            Add(Year, Month.December, 8, "Immaculate Conception Day");
            Add(ChristmasDay, "Christmas Day");
            Add(Year, Month.December, 31, "Public Holiday");
            return this;
        }

    }
}

/*
  Notes
    * If the date falls on a Wednesday, the holiday is the preceding Monday. If it falls on a Thursday then the holiday is the following Monday.
    * If the holiday is on Tuesday, Monday is added as a holiday day. If the holiday is on Thursday, then Friday is granted as holiday.
    * The rules above can lead to a lot of annual Public holidays, but most Argentinians only get 10 vacation days, rising to 15 days if they have worked for more than 5 years in a company.
*/
