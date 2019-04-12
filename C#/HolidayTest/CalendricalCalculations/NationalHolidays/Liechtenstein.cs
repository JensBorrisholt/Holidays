namespace CalendricalCalculation.NationalHolidays
{
    public class Liechtenstein : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's day");
            Add(Epiphany, "Epiphany");
            Add(Year, Month.February, 2, "Candlemas");
            Add(Year, Month.March, 19, "St. Joseph's Day");
            Add(EasterSunday, "Easter Sunday");
            Add(EasterMonday, "Easter Monday");
            Add(LaborDay, "LaborDay");
            Add(AscensionDay, "Ascension Day");
            Add(WhitSunday, "Whit Sunday");
            Add(WhitMonday, "Whit Monday");
            Add(Year, Month.June, 11, "Corpus Christi");
            Add(Year, Month.August, 15, "Liechtenstein National Day");
            Add(Year, Month.September, 8, "Nativity of Our Lady");
            Add(Year, Month.November, 1, "All Saints' Day");
            Add(Year, Month.December, 8, "Immaculate Conception Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

//NOTE:
//  I only have the English names for the holiday
// If you know the translation to the native language 
// pleae add them 
