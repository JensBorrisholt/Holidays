using System;
using System.Collections.Generic;
using System.Text;

namespace CalendricalCalculation.NationalHolidays
{
    public class Norway : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Søndag";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(PalmSunday, "Palmesøndag", "Palm Sunday");
            Add(MaundyThursday, "Skjærtorsdag", "Maundy Thursday");
            Add(GoodFriday, "Langfredag", "Good Friday");
            Add(EasterSunday, "1. Påskedag", "Easter Sunday");
            Add(EasterMonday, "2. Påskedag", "Easter Monday");
            
            Add(AscensionDay, "Kristi Himmelfart", "Ascension Day");
            Add(WhitSunday, "1. Pinsedag", "Whit Sunday");
            Add(WhitMonday, "2. Pinsedag", "Whit Monday");

            //Static Holidays
            Add(NewYearsDay, "1. Nyttårsdag", "New Year's day");
            Add(LaborDay, "Arbeidernes dag", "Labor Day");
            Add(Year, Month.May, 17, "Nasjonaldag", "Constitution Day");
            Add(ChristmasDay, "1. Juledag", "Christmas Day");
            Add(BoxingDay, "2. Juledag", "Boxing Day");
            return this;
        }
    }
}
