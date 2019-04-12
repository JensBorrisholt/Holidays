namespace CalendricalCalculation.NationalHolidays
{
    public class Austria : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Epiphany, "Epiphany");
            Add(EasterMonday, "Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(AscensionDay, "Ascension Day");
            Add(WhitMonday, "Whit Monday");
            Add(Year, Month.June, 11, "Corpus Christi");
            Add(Year, Month.August, 15, "Assumption Day");
            Add(Year, Month.October, 26, "National Day");
            Add(Year, Month.November, 1, "All Saints Day");
            Add(Year, Month.December, 8, "Immaculate Conception Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "St. Stephen's Day");
            return this;
        }
    }
}

/*
  Notes
    * Holidays falling on Saturday and Sunday are not substituted by a weekday
*/
