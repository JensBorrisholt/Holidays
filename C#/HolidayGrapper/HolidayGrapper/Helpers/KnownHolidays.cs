using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace HolidayGrapper.Helpers
{
    public abstract class KnownHolidays : List<Holiday>
    {
        public enum Month
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        /// <summary>
        /// Get Orthodox easter for requested year
        /// </summary>
        /// <param name="year">Year of easter</param>
        /// <returns>DateTime of Orthodox Easter</returns>
        public static DateTime GetOrthodoxEaster(int year)
        {
            var a = year % 19;
            var b = year % 7;
            var c = year % 4;

            var d = (19 * a + 16) % 30;
            var e = (2 * c + 4 * b + 6 * d) % 7;
            var f = (19 * a + 16) % 30;

            var key = f + e + 3;
            var month = (key > 30) ? 5 : 4;
            var day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }

        public static DateTime GetEasterDay(int year)
        {
            /*
                This algorithm is based in part on the algorithm of Oudin (1940) as quoted in
                "Explanatory Supplement to the Astronomical Almanac", P. Kenneth Seidelmann.

                G is the Golden Number -1
                H is 23-Epact (modulo 30)
                I is the number of days from 21 March to the Paschal full moon
                J is the weekday for the Paschal full moon (0=Sunday, 1=Monday, etc.)
                L is the number of days from 21 March to the Sunday on or before the Paschal full moon (a number between -6 and 28)
                C is  Century
            */

            var g = year % 19;
            var c = year / 100;

            var x = c / 4;
            var y = (8 * c + 13) / 25;
            var z = 19 * g;
            var h = (c - x - y + z + 15) % 30;

            x = h / 28;
            y = 29 / (h + 1);
            z = (21 - g) / 11;
            var I = h - x * (1 - y * z);

            x = year / 4;
            y = c / 4;
            var j = (year + x + I + 2 - c + y) % 7;

            var l = I - j;
            x = (l + 40) / 44;

            var easterMonth = 3 + x;
            x = easterMonth / 4;

            var easterDay = l + 28 - 31 * x;

            return new DateTime(year, easterMonth, easterDay);
        }

        public DateTime EasterSunday { get; }
        public DateTime OrthodoxEasterSunday { get; }

        protected KnownHolidays(int year)
        {
            Year = year;
            EasterSunday = GetEasterDay(year);
            OrthodoxEasterSunday = GetOrthodoxEaster(year);
            AddStaticHoliDays();
        }

        public static KnownHolidays GetList(int year, bool orthodox) => orthodox ? (KnownHolidays) new KnownOrthodoxHolidays(year) : new KnowCatholicHolidays(year);

        protected void Add(string englishName, string nativeName, DateTime date) => Add(new Holiday(date, nativeName, englishName));

        private void AddStaticHoliDays()
        {
            #region Static Holidays
            Add("NewYearsDay", "New Year's day", new DateTime(Year, (int)Month.January, 1));
            Add("Epiphany", "Epiphany", new DateTime(Year, (int)Month.January, 6));
            Add("LaborDay", "LaborDay", new DateTime(Year, (int)Month.May, 1));
            Add("ChristmasDay", "Christmas Day", new DateTime(Year, (int)Month.December, 25));
            Add("BoxingDay", "Boxing Day", new DateTime(Year, (int)Month.December, 26));
            #endregion

            AddHolidays();
        }

        protected abstract void AddHolidays();
        
        public int Year { get; }
    }
}
