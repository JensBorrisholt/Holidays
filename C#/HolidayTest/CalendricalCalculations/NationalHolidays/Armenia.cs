using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Armenia : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.January, 2, "New Year's Holiday");
            Add(Year, Month.January, 3, "New Year's Holiday");
            Add(Year, Month.January, 4, "New Year's Holiday");
            Add(Year, Month.January, 5, "Armenian Christmas Eve");
            Add(Epiphany, "Armenian Christmas Day");
            Add(Year, Month.January, 28, "National Army Day");
            Add(Year, Month.March, 8, "Women's Day");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.April, 24, "Genocide Memorial Day");
            Add(LaborDay, "Labor Day");
            Add(Year, Month.May, 9, "Victory Day");
            Add(Year, Month.May, 28, "Day of the First Republic");
            Add(Year, Month.July, 5, "Constitution Day");
            //Monday after Sunday between 11 - 17 September
            var dt = new DateTime(Year, (int)Month.September, 11);
            while (dt.DayOfWeek != DayOfWeek.Sunday)
                dt = dt.AddDays(1);
            dt = dt.AddDays(1);

            Add(dt, "Exaltation of the Holy Cross");

            Add(Year, Month.September, 21, "Independence Day");
            Add(Year, Month.December, 31, "New Year's Eve");
            return this;
        }
    }
}

//NOTE:
//  I only have the English names for the holiday
// If you know the translation to the native language 
// pleae add them 
