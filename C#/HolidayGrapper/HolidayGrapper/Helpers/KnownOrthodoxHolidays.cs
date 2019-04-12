using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayGrapper.Helpers
{
    public class KnownOrthodoxHolidays : KnownHolidays
    {
        protected void Add(string englishName, string nativeName, int dxEaster) => Add(new Holiday(OrthodoxEasterSunday.AddDays(dxEaster), nativeName, englishName));
        public KnownOrthodoxHolidays(int year) : base(year)
        {
        }

        protected override void AddHolidays()
        {
            Add("Orthodox_MaundyThursday", "Orthodox Maundy Thursday", -3);
            Add("Orthodox_GoodFriday", "Orthodox Good Friday", -2);
            Add("Orthodox_HolySaturday", "Orthodox Holy Saturday", -1);
            Add("Orthodox_EasterSunday", "Orthodox Easter Sunday", 0);
            Add("Orthodox_EasterMonday", "Orthodox Easter Monday", 1);
            Add("Orthodox_AscensionDay", "Orthodox Ascension Day", 39);
            Add("Orthodox_WhitSunday", "Orthodox Whit Sunday", 49);
            Add("Orthodox_WhitMonday", "Orthodox Whit Monday", 50);
            Add("Orthodox_Christmas_Day", "Orthodox Christmas Day", new DateTime(Year, (int)Month.January, 7 ));

        }
    }
}
