namespace CalendricalCalculation.NationalHolidays
{
    public class Belarus : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Orthodox_Christmas_Day, "Orthodox Christmas Day");
            Add(Year, Month.March, 8, "Women's Day");
            Add(LaborDay, "Labour Day");

            Add(Orthodox_EasterSunday, "Orthodox Easter Day");
            //Radonitsa. 9 days after Orthodox Easter
            Add(Orthodox_EasterSunday.AddDays(9), "Commemoration Day");

            Add(Year, Month.May, 9, "Victory Day");
            if (Year > 1944)
                Add(Year, Month.July, 3, "Independence Day"); //Liberation of Belarus from the Nazis in 1944

            if (Year > 1917) //Commemorates the Russian Revolution of 1917
                Add(Year, Month.November, 7, "October Revolution Day");

            Add(Year, Month.December, 24, "Christmas Eve");
            Add(ChristmasDay, "Christmas Day (Catholic)");
            return this;
        }
    }
}

