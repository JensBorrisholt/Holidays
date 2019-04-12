namespace CalendricalCalculation.NationalHolidays
{
    public class Cyprus : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Epiphany, "Epiphany");
            Add(Year, Month.March, 11, "Green Monday");
            Add(Year, Month.March, 25, "Greek Independence Day");
            Add(Year, Month.April, 1, "Cyprus National Day");
            Add(Orthodox_GoodFriday, "Orthodox Good Friday");
            Add(Orthodox_EasterMonday, "Orthodox Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(Orthodox_WhitMonday, "Pentecost Monday");
            Add(Year, Month.August, 15, "Dormition of the Theotokos");
            Add(Year, Month.October, 1, "Cyprus Independence Day");
            Add(Year, Month.October, 28, "The Ochi day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

/*
  Notes
    * Holidays that fall on a weekend are not moved to the following Monday
*/
