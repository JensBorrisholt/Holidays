using System;
using System.Collections.Generic;
using System.Text;

namespace CalendricalCalculation.NationalHolidays
{
    public class Sweden : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Söndag";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(GoodFriday, "Långfredag", "Good Friday");
            Add(EasterSunday, "Påskdagen", "Easter Sunday");
            Add(EasterMonday, "Annandag påsk", "Easter Monday");

            Add(AscensionDay, "Kristi himmelsfärdsdag", "Ascension Day");
            Add(WhitSunday, "Pingstdagen", "Whit Sunday");
            Add(WhitMonday, "Annandag Pingst", "Whit monday");

            // First sunday on or after June 19.
            var dt = new DateTime(Year, (int)Month.June, 19);
            while (dt.DayOfWeek != DayOfWeek.Sunday)
                dt = dt.AddDays(1);

            Add(dt, "Midsommardagen", "Midsummer Day");

            // Saturday on or after 30 October
            dt = new DateTime(Year, (int)Month.October, 30);
            while (dt.DayOfWeek != DayOfWeek.Saturday)
                dt = dt.AddDays(1);
            Add(dt, "Alla helgons dag", "All Saints' Eve");

            Add(NewYearsDay, "Nyårsdagen", "New Year's day");
            Add(Year, Month.January, 6, "Trettondagen", "Epiphany");
            Add(LaborDay, "Första maj", "Labor Day");
            Add(ChristmasDay, "Juldagen", "Christmas Day");
            Add(BoxingDay, "Annandag jul", "Boxing Day");
            return this;
        }
    }
}
