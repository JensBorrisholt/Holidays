using System;

namespace CalendricalCalculation.NationalHolidays
{
    public class Aruba : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.January, 25, "Betico Croes Day");
            Add(AshWdensday.AddDays(-1), "Carnival Monday"); //Celebrated on Monday before Ash Wednesday
            Add(Year, Month.March, 18, "National Anthem and Flag Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");

            var dt = new DateTime(Year, (int) Month.April, 27);
            if (dt.DayOfWeek == DayOfWeek.Sunday)
                dt = dt.AddDays(-1); //If 27th is a Sunday, celebrations are held on 26th
            Add(dt, "King's Birthday");

            Add(LaborDay, "Labour Day");
            Add(AscensionDay, "Ascension Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

