namespace CalendricalCalculation.NationalHolidays
{
    public class Brazil : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.February, 25, "Carnival");
            Add(GoodFriday, "Good Friday");
            Add(Year, Month.April, 21, "Tiradentes Day");
            Add(LaborDay, "Labour Day");
            Add(Year, Month.June, 11, "Corpus Christi");
            Add(Year, Month.September, 7, "Independence Day");
            Add(Year, Month.October, 12, "Lady of Aparecida");
            Add(Year, Month.November, 2, "All Souls' Day");
            Add(Year, Month.November, 15, "Republic Day");
            Add(ChristmasDay, "Christmas Day");
            return this;
        }
    }
}

/*
  Notes
    * Ponto facultativos are types of holidays unique to Brazil. It is up to an employer whether they allow employees to take this day. In practice, the holidays are widely observed by the public sector and large companies.
    * Half Day holidays are observed on Christmas Eve (December 24th) and New Year's Eve (December 31st)
*/
