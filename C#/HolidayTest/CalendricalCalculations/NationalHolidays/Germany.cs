using System;
using System.Collections.Generic;
using System.Text;

namespace CalendricalCalculation.NationalHolidays
{
    public class Germany : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sontag";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(GoodFriday, "Karfreitag", "Good Friday");
            Add(EasterSunday, "Ostersonntag", "Easter Sunday");
            Add(EasterMonday, "Ostermontag", "Easter Monday");
            Add(AscensionDay, "Christi Himmelfahrt", "Ascension Day");
            Add(WhitSunday, "Pfingstsonntag", "White Sunday");
            Add(WhitMonday, "Pfingstmontag", "White Monday");

            Add(Number.Third, DayOfWeek.Wednesday, Month.November, Year, "Buß- und Bettag", "Day of prayer and repentance");

            Add(NewYearsDay, "Neujahr", "New Year's day");
            Add(LaborDay, "Tag der Arbeit", "Labor Day");

            if (Year > 1989)
                Add(Year, Month.October, 3, "Tag der deutschen Einheit", "German reunification Day");

            Add(Year, Month.October, 31, "Reformationstag", "Reformation Day");
            Add(ChristmasDay, "Weihnachtsfeiertag", "Christmas Day");
            Add(BoxingDay, "Weihnachtsfeiertag", "Boxing Day");

            return this;
        }
    }
}
