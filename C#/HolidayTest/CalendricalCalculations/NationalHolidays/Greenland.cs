using System;
using System.Collections.Generic;
using System.Text;

namespace CalendricalCalculation.NationalHolidays
{
    public class Greenland : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sapaat";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(MaundyThursday, "Skærtorsdag", "Maundy Thursday");
            Add(GoodFriday, "Langfredag", "Good Friday");
            Add(EasterSunday, "Påskedag", "Easter Sunday");
            Add(EasterMonday, "2. Påskedag", "Easter Monday");
            Add(AscensionDay, "Kristi Himmelfartsdag", "Ascension Day");
            Add(WhitSunday, "Pinsedag", "Whit Sunday");
            Add(WhitMonday, "2. Pinsedag", "Whit monday");

            //Static Holidays
            Add(NewYearsDay, "Nytårsdag", "New Year's day");
            Add(Year, Month.June, 05, "Grundlovsdag", "Constitution Day");
            Add(Year, Month.June, 21, "Inuiattut ullorsiorneq", "Constitution Day");
            Add(ChristmasDay, "Juledag", "Christmas Day");
            Add(BoxingDay, "2. Juledag", "Boxing Day");
            return this;
        }
    }
}
