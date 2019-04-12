namespace CalendricalCalculation.NationalHolidays
{
    public class Bahamas : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.January, 10, "Majority Rule Day");
            Add(GoodFriday, "Good Friday");
            Add(EasterMonday, "Easter Monday");
            Add(Year, Month.June, 7, "Randol Fawkes Labor Day");
            Add(WhitMonday, "Whit Monday");
            Add(Year, Month.July, 10, "Independence Day");
            Add(Year, Month.August, 5, "Emancipation Day");
            Add(Year, Month.October, 14, "National Heroes Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

/*
  Notes
    * Holidays that fall on a Saturday or Sunday are usually celebrated on the following Monday
    * Holidays that fall on Tuesday are usually celebrated on the previous Monday
    * Holidays that fall on a Wednesday or a Thursday are celebrated on the following Friday (with the exception of Independence Day, Christmas Day and Boxing Day)
    * Banks/businesses and many shops are closed on public holidays
*/
