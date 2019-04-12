using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Danish : BaseNationalHolidays
    {
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(PalmSunday, "Palmesøndag", "Palm Sunday");
            Add(MaundyThursday, "Skærtorsdag", "Maundy Thursday");
            Add(GoodFriday, "Langfredag", "Good Friday");
            Add(EasterSunday, "Påskedag", "Easter Sunday");
            Add(EasterMonday, "2. Påskedag", "Easter Monday");
            Add(EasterSunday.AddDays(26), "Store Bededag", "Prayer Day");
            Add(AscensionDay, "Kristi Himmelfartsdag", "Ascension Day");
            Add(WhitSunday, "Pinsedag", "Whit Sunday");
            Add(WhitMonday, "2. Pinsedag", "Whit monday");
            
            //Static Holidays
            Add(NewYearsDay, "Nytårsdag", "New Year's day");
            Add(Year, Month.June, 05, "Grundlovsdag", "Constitution Day");
            Add(ChristmasDay, "Juledag", "Christmas Day");
            Add(BoxingDay, "2. Juledag", "Boxing Day");
            return this;
        }

        public override string SundayName { get; } = "Søndag";
        
    }
}
