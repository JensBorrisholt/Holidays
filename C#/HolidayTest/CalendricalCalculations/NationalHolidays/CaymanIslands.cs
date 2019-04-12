using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class CaymanIslands : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Number.Fourth,  DayOfWeek.Monday,  Month.January, Year, "National Heroes Day");
            Add(AshWdensday, "Ash Wednesday");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.May, 20, "Discovery Day");
            Add(WhitMonday, "Whit Monday");
            Add(NthDayInMonth(Number.Second, DayOfWeek.Monday, Month.June, Year).AddDays(2), "Queen's Birthday"); //Monday after second Saturday in June
            Add(Number.First, DayOfWeek.Monday,  Month.July, Year, "Constitution Day");
            Add(Number.Second, DayOfWeek.Monday,  Month.November, Year, "Remembrance Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

