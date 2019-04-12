namespace CalendricalCalculation.NationalHolidays
{
    public class Bulgaria : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.March, 3, "Liberation Day");
            Add(Year, Month.March, 4, "Liberation Day Holiday");
            Add(Orthodox_GoodFriday, "Orthodox Good Friday");
            Add(Orthodox_HolySaturday, "Orthodox Holy Saturday");
            Add(Orthodox_EasterSunday, "Orthodox Easter Day");
            Add(Orthodox_EasterMonday, "Orthodox Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(Year, Month.May, 6, "St Georges Day");
            Add(Year, Month.May, 24, "Culture and Literacy Day");
            Add(Year, Month.September, 6, "Unification Day");
            Add(Year, Month.September, 22, "Independence Day");
            Add(Year, Month.September, 23, "Independence Day Holiday");
            Add(Year, Month.December, 24, "Christmas Eve");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Second Day of Christmas");
            return this;
        }
    }
}

/*
  Notes
    * If a holiday falls on a weekend, the following weekday will be a holiday
*/
