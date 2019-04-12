namespace CalendricalCalculation.NationalHolidays
{
    public class Chile : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(GoodFriday, "Good Friday");
            Add(HolySaturday, "Holy Saturday");
            Add(LaborDay, "Labour Day");
            Add(Year, Month.May, 21, "Navy Day");
            Add(Year, Month.July, 1, "Saint Peter and Saint Paul Day Holiday");
            Add(Year, Month.July, 16, "Our Lady of Mount Carmel");
            Add(Year, Month.August, 15, "Assumption Day"); //Assumption of Mary
            Add(Year, Month.September, 18, "Independence Day of Chile");
            Add(Year, Month.September, 19, "Army Day");
            Add(Year, Month.October, 14, "Race Day Holiday");
            if (Year >= 2018)
                Add(Year, Month.October, 31, "Reformation Day");

            Add(Year, Month.November, 1, "All Saints' Day");

            Add(Year, Month.December, 8, "Immaculate Conception Day");
            Add(ChristmasDay, "Christmas Day");
            return this;
        }
    }
}

/*
  Notes
    * Most modern Chilean holidays were enshrined in law on January 28, 1915.
    * Presidential elections, parliamentary and municipal elections and censuses are declared holidays.
    * Reformation Day
        In Chile, this holiday is called 'Día Nacional de las Iglesias Evangélicas y Protestantes' and was established as a holiday in 2008. 
        It is usually celebrated on 31st October, but moved to the preceding Friday if it falls on a Tuesday, or to the following Friday if it falls on a Wednesday
*/
