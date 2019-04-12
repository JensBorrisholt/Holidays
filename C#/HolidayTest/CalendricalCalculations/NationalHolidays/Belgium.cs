namespace CalendricalCalculation.NationalHolidays
{
    public class Belgium : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(EasterMonday, "Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(AscensionDay, "Ascension Day");
            Add(WhitMonday, "Pentecost Monday");
            Add(Year, Month.July, 21, "Independence Day");
            Add(Year, Month.August, 15, "Assumption Day");
            Add(Year, Month.November, 1, "All Saints Day");
            Add(Year, Month.November, 11, "Armistice Day");
            Add(ChristmasDay, "Christmas Day");
            return this;
        }
    }
}

/*
  Notes
    * The three community days are holidays for their government and administrative employees and may also be observed by banks in the community.
    * Bank holidays that fall in a weekend will NOT be held any other day.
    * In Belgium there are twelve 'official' public holidays, though two of them fall on a Sunday - Easter Sunday and Whitsun (Pentecost).
    * Other holidays may also celebrated, but these are not official public holidays.
*/
