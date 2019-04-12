using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CalendricalCalculation.NationalHolidays;

namespace CalendricalCalculation
{
    public class Holidays<T> : IEnumerable<Holiday> where T : BaseNationalHolidays, new()
    {
        private BaseNationalHolidays _holyDayList;
        public bool IncludeSunday { get; }
        public bool IncludeHolidays { get; }
        public int Year { get; }

        public Holidays(int year = 0, bool includeSunday = true, bool includeHolidays = true)
        {
            IncludeHolidays = includeHolidays;
            IncludeSunday = includeSunday;
            if (year == 0)
                year = DateTime.Now.Year;

            Year = year;
            MakeHoliDays();
        }
        
        private void MakeHoliDays()
        {
            _holyDayList = new T { Year = this.Year };

            if (IncludeHolidays)
                _holyDayList.MakeHolydays();

            if (IncludeSunday)
            {
                var startOfTheYear = new DateTime(Year, 1, 1);
                var firstSunday = startOfTheYear.DayOfWeek == DayOfWeek.Sunday ? startOfTheYear : startOfTheYear.AddDays(7 - (startOfTheYear.DayOfWeek - DayOfWeek.Sunday));

                var endOfTheYear = new DateTime(Year, 12, 31);
                var lastSunday = endOfTheYear.AddDays(DayOfWeek.Sunday - endOfTheYear.DayOfWeek);

                for (var day = firstSunday; day <= lastSunday; day = day.AddDays(7))
                    _holyDayList.Add(new Holiday(day, _holyDayList.SundayName, "Sunday"));
            }
            
            _holyDayList.Sort((x, y) => x.Date.CompareTo(y.Date));
        }

        public IEnumerator<Holiday> GetEnumerator() => _holyDayList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
