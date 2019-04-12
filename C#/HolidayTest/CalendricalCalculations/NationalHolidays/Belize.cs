namespace CalendricalCalculation.NationalHolidays
{
    public class Belize : BaseNationalHolidays
    {
        public override string SundayName { get; } = "Sunday";
        public override BaseNationalHolidays MakeHolydays()
        {
            Add(NewYearsDay, "New Year's Day");
            Add(Year, Month.March, 9, "National Heroes and Benefactors Day");
            Add(GoodFriday, "Good Friday");
            Add(HolySaturday, "Holy Saturday");
            Add(EasterMonday, "Easter Monday");
            Add(LaborDay, "Labour Day");
            Add(Year, Month.May, 25, "Sovereign's Day/commonwealth Day");
            Add(Year, Month.September, 7, "St. George's Caye Day");
            Add(Year, Month.September, 21, "Independence Day");
            Add(Year, Month.October, 12, "Pan American Day");
            Add(Year, Month.November, 19, "Garifuna Settlement Day");
            Add(ChristmasDay, "Christmas Day");
            Add(BoxingDay, "Boxing Day");
            return this;
        }
    }
}

/*
  Notes
    * Chapter 289 of the laws of Belize states that if the holiday falls on a Sunday, the following Monday is observed as the bank and public holiday.
    * Chapter 289 of the laws of Belize states that if the holiday falls on a Sunday or a Friday, the following Monday is observed as the bank and public holiday; further, if the holiday falls on a Tuesday, Wednesday or Thursday, the preceding Monday is observed as the bank and public holiday.
*/
