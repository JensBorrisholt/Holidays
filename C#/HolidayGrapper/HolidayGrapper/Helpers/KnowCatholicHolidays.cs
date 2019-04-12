using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayGrapper.Helpers
{
    public class KnowCatholicHolidays : KnownHolidays
    {
        protected void Add(string englishName, string nativeName, int dxEaster) => Add(new Holiday(EasterSunday.AddDays(dxEaster), nativeName, englishName));

        public KnowCatholicHolidays(int year) : base(year)
        {
        }

        protected override void AddHolidays()
        {
            #region Shifting Holidays
            Add("AshWdensday", "Ash Wdensday", -46);
            Add("PalmSunday", "Palm Sunday", -7);
            Add("MaundyThursday", "Maundy Thursday", -3);
            Add("GoodFriday", "Good Friday", -2);
            Add("HolySaturday", "Holy Saturday", -1);
            Add("EasterSunday", "Easter Sunday", 0);
            Add("EasterMonday", "Easter Monday", 1);
            Add("AscensionDay", "Ascension Day", 39);
            Add("WhitSunday", "Whit Sunday", 49);
            Add("WhitMonday", "Whit Monday", 50);
            #endregion

        }
    }
}
