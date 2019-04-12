namespace CalendricalCalculation.NationalHolidays
{
    public class Gibraltar : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.March, 11, "Commonwealth Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.April, 29, "Workers Memorial Day");
            Add(LaborDay, "May Day");
            Add(Year, Month.May, 27, "Spring Bank Holiday");
            Add(Year, Month.June, 17, "Queen's Birthday");
            Add(Year, Month.August, 26, "Late Summer Bank Holiday");
            Add(Year, Month.September, 10, "National Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

