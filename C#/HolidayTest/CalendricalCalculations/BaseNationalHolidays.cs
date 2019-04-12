using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
//https://www.officeholidays.com/countries/index.php
namespace CalendricalCalculation.NationalHolidays
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class BaseNationalHolidays : List<Holiday>
    {
        private int _year;
        protected const int DaysPerWeek = 7;

        protected enum Number
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Last = 5
        };

        protected enum Month
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

        #region Shifting Holidays
        public DateTime AshWdensday => EasterSunday.AddDays(-46);
        public DateTime PalmSunday => EasterSunday.AddDays(-7);
        public DateTime MaundyThursday => EasterSunday.AddDays(-3);
        public DateTime GoodFriday => EasterSunday.AddDays(-2);
        public DateTime HolySaturday => EasterSunday.AddDays(-1);
        public DateTime EasterSunday { get; private set; }
        public DateTime EasterMonday => EasterSunday.AddDays(1);
        public DateTime AscensionDay => EasterSunday.AddDays(39);
        public DateTime WhitSunday => EasterSunday.AddDays(49);
        public DateTime WhitMonday => EasterSunday.AddDays(50);

        public DateTime Orthodox_MaundyThursday => Orthodox_EasterSunday.AddDays(-3);
        public DateTime Orthodox_GoodFriday => Orthodox_EasterSunday.AddDays(-2);
        public DateTime Orthodox_HolySaturday => Orthodox_EasterSunday.AddDays(-1);

        public DateTime Orthodox_EasterSunday { get; private set; }
    
        public DateTime Orthodox_EasterMonday => Orthodox_EasterSunday.AddDays(1);
        public DateTime Orthodox_AscensionDay => Orthodox_EasterSunday.AddDays(39);
        public DateTime Orthodox_WhitSunday => Orthodox_EasterSunday.AddDays(49);
        public DateTime Orthodox_WhitMonday => Orthodox_EasterSunday.AddDays(50);
        public DateTime Orthodox_Christmas_Day => new DateTime(Year, (int)Month.January, 7);

        #endregion

        #region Static Holidays
        public DateTime NewYearsDay => new DateTime(Year, (int)Month.January, 1);
        public DateTime Epiphany => new DateTime(Year, (int)Month.January, 6);
        public DateTime LaborDay => new DateTime(Year, (int)Month.May, 1);
        public DateTime ChristmasDay => new DateTime(Year, (int)Month.December, 25);
        public DateTime BoxingDay => new DateTime(Year, (int)Month.December, 26);
        #endregion


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

            int g = year % 19;
            int c = year / 100;

            int x = c / 4;
            int y = (8 * c + 13) / 25;
            int z = 19 * g;
            int h = (c - x - y + z + 15) % 30;

            x = h / 28;
            y = 29 / (h + 1);
            z = (21 - g) / 11;
            int I = h - x * (1 - y * z);

            x = year / 4;
            y = c / 4;
            int j = (year + x + I + 2 - c + y) % 7;

            int l = I - j;
            x = (l + 40) / 44;

            int easterMonth = 3 + x;
            x = easterMonth / 4;

            int easterDay = l + 28 - 31 * x;

            return new DateTime(year, easterMonth, easterDay);
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                EasterSunday = GetEasterDay(_year);
                Orthodox_EasterSunday = GetOrthodoxEaster(_year);

            }
        }

        protected DateTime NthDayInMonth(Number number, DayOfWeek day, Month month, int year)
        {
            DateTime result;
            if (number == Number.Last)
            {
                result = new DateTime(year, (int)month, 1).AddMonths(1).AddDays(-1);
                while (result.DayOfWeek != day)
                    result = result.AddDays(-1);
            }
            else
            {
                result = new DateTime(year, (int)month, 1);
                while (result.DayOfWeek != day)
                    result = result.AddDays(1);

                result = result.AddDays(((int)number - 1) * DaysPerWeek);
            }

            return result;
        }

        protected Holiday Add(DateTime date, string nativeName, string englishName = "")
        {
            Add(new Holiday(date, nativeName, englishName));
            return this.Last();
        }

        protected Holiday Add(int year, Month month, int day, string nativeName, string englishName = "")
            => Add(new DateTime(year, (int)month, day), nativeName, englishName);

        protected Holiday Add(Number number, DayOfWeek day, Month month, int year, string nativeName, string englishName = "")
            => Add(NthDayInMonth(number, day, month, year), nativeName, englishName);

        public abstract string SundayName { get; }
        public abstract BaseNationalHolidays MakeHolydays();
    }
}
