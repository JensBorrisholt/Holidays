using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CalendricalCalculation;
using CalendricalCalculation.NationalHolidays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendicalCalculationsTest
{
    public static class EnumerableExtention
    {
        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing(new Random());
        }

        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            var index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
    }

    [TestClass]
    public class HoliDayTest
    {
        private List<TestElement> _testData;

        //Expected format:         
        //1950;2. april;6. april;7. april;9. april;10. april;5. maj;18. maj;28. maj;29. maj
        public TestElement GetTestElement(string s)
        {
            var names = new[]
            {
                "År", "Palmesøndag", "Skærtorsdag", "Langfredag", "Påskedag", "2. Påskedag", "Store Bededag",
                "Kristi Himmelfartsdag", "Pinsedag", "2. Pinsedag"
            };
            var buf = s.Split(';');
            var year = buf[0];
            var holidays = new List<Holiday>();

            for (var i = 1; i < buf.Length; i++)
                holidays.Add(new Holiday(DateTime.Parse(buf[i] + ' ' + year), names[i], ""));

            var iYear = holidays.First().Date.Year;

            //Static Holidays
            holidays.Add(new Holiday(new DateTime(iYear, 01, 01), "Nytårsdag", "New Year's day"));
            holidays.Add(new Holiday(new DateTime(iYear, 06, 05), "Grundlovsdag", "Constitution Day"));
            holidays.Add(new Holiday(new DateTime(iYear, 12, 25), "Juledag", "Christmas Day"));
            holidays.Add(new Holiday(new DateTime(iYear, 12, 26), "2. Juledag", "Boxing Day"));
            
            return new TestElement(iYear, holidays);
        }

        [TestInitialize]
        public void Setup()
        {
            //Source for test data: http://da.wikipedia.org/wiki/Danske_helligdage
            var shiftingHolidays =
                @"
                1950;2. april;6. april;7. april;9. april;10. april;5. maj;18. maj;28. maj;29. maj
                1951;18. marts;22. marts;23. marts;25. marts;26. marts;20. april;3. maj;13. maj;14. maj
                1952;6. april;10. april;11. april;13. april;14. april;9. maj;22. maj;1. juni;2. juni
                1953;29. marts;2. april;3. april;5. april;6. april;1. maj;14. maj;24. maj;25. maj
                1954;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                1955;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                1956;25. marts;29. marts;30. marts;1. april;2. april;27. april;10. maj;20. maj;21. maj
                1957;14. april;18. april;19. april;21. april;22. april;17. maj;30. maj;9. juni;10. juni
                1958;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                1959;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                1960;10. april;14. april;15. april;17. april;18. april;13. maj;26. maj;5. juni;6. juni
                1961;26. marts;30. marts;31. marts;2. april;3. april;28. april;11. maj;21. maj;22. maj
                1962;15. april;19. april;20. april;22. april;23. april;18. maj;31. maj;10. juni;11. juni
                1963;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                1964;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                1965;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                1966;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                1967;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                1968;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                1969;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                1970;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                1971;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                1972;26. marts;30. marts;31. marts;2. april;3. april;28. april;11. maj;21. maj;22. maj
                1973;15. april;19. april;20. april;22. april;23. april;18. maj;31. maj;10. juni;11. juni
                1974;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                1975;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                1976;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                1977;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                1978;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                1979;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                1980;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                1981;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                1982;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                1983;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                1984;15. april;19. april;20. april;22. april;23. april;18. maj;31. maj;10. juni;11. juni
                1985;31. marts;4. april;5. april;7. april;8. april;3. maj;16. maj;26. maj;27. maj
                1986;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                1987;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                1988;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                1989;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                1990;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                1991;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                1992;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                1993;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                1994;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                1995;9. april;13. april;14. april;16. april;17. april;12. maj;25. maj;4. juni;5. juni
                1996;31. marts;4. april;5. april;7. april;8. april;3. maj;16. maj;26. maj;27. maj
                1997;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                1998;5. april;9. april;10. april;12. april;13. april;8. maj;21. maj;31. maj;1. juni
                1999;28. marts;1. april;2. april;4. april;5. april;30. april;13. maj;23. maj;24. maj
                2000;16. april;20. april;21. april;23. april;24. april;19. maj;1. juni;11. juni;12. juni
                2001;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                2002;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                2003;13. april;17. april;18. april;20. april;21. april;16. maj;29. maj;8. juni;9. juni
                2004;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                2005;20. marts;24. marts;25. marts;27. marts;28. marts;22. april;5. maj;15. maj;16. maj
                2006;9. april;13. april;14. april;16. april;17. april;12. maj;25. maj;4. juni;5. juni
                2007;1. april;5. april;6. april;8. april;9. april;4. maj;17. maj;27. maj;28. maj
                2008;16. marts;20. marts;21. marts;23. marts;24. marts;18. april;1. maj;11. maj;12. maj
                2009;5. april;9. april;10. april;12. april;13. april;8. maj;21. maj;31. maj;1. juni
                2010;28. marts;1. april;2. april;4. april;5. april;30. april;13. maj;23. maj;24. maj
                2011;17. april;21. april;22. april;24. april;25. april;20. maj;2. juni;12. juni;13. juni
                2012;1. april;5. april;6. april;8. april;9. april;4. maj;17. maj;27. maj;28. maj
                2013;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                2014;13. april;17. april;18. april;20. april;21. april;16. maj;29. maj;8. juni;9. juni
                2015;29. marts;2. april;3. april;5. april;6. april;1. maj;14. maj;24. maj;25. maj
                2016;20. marts;24. marts;25. marts;27. marts;28. marts;22. april;5. maj;15. maj;16. maj
                2017;9. april;13. april;14. april;16. april;17. april;12. maj;25. maj;4. juni;5. juni
                2018;25. marts;29. marts;30. marts;1. april;2. april;27. april;10. maj;20. maj;21. maj
                2019;14. april;18. april;19. april;21. april;22. april;17. maj;30. maj;9. juni;10. juni
                2020;5. april;9. april;10. april;12. april;13. april;8. maj;21. maj;31. maj;1. juni
                2021;28. marts;1. april;2. april;4. april;5. april;30. april;13. maj;23. maj;24. maj
                2022;10. april;14. april;15. april;17. april;18. april;13. maj;26. maj;5. juni;6. juni
                2023;2. april;6. april;7. april;9. april;10. april;5. maj;18. maj;28. maj;29. maj
                2024;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                2025;13. april;17. april;18. april;20. april;21. april;16. maj;29. maj;8. juni;9. juni
                2026;29. marts;2. april;3. april;5. april;6. april;1. maj;14. maj;24. maj;25. maj
                2027;21. marts;25. marts;26. marts;28. marts;29. marts;23. april;6. maj;16. maj;17. maj
                2028;9. april;13. april;14. april;16. april;17. april;12. maj;25. maj;4. juni;5. juni
                2029;25. marts;29. marts;30. marts;1. april;2. april;27. april;10. maj;20. maj;21. maj
                2030;14. april;18. april;19. april;21. april;22. april;17. maj;30. maj;9. juni;10. juni
                2031;6. april;10. april;11. april;13. april;14. april;9. maj;22. maj;1. juni;2. juni
                2032;21. marts;25. marts;26. marts;28. marts;29. marts;23. april;6. maj;16. maj;17. maj
                2033;10. april;14. april;15. april;17. april;18. april;13. maj;26. maj;5. juni;6. juni
                2034;2. april;6. april;7. april;9. april;10. april;5. maj;18. maj;28. maj;29. maj
                2035;18. marts;22. marts;23. marts;25. marts;26. marts;20. april;3. maj;13. maj;14. maj
                2036;6. april;10. april;11. april;13. april;14. april;9. maj;22. maj;1. juni;2. juni
                2037;29. marts;2. april;3. april;5. april;6. april;1. maj;14. maj;24. maj;25. maj
                2038;18. april;22. april;23. april;25. april;26. april;21. maj;3. juni;13. juni;14. juni
                2039;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                2040;25. marts;29. marts;30. marts;1. april;2. april;27. april;10. maj;20. maj;21. maj
                2041;14. april;18. april;19. april;21. april;22. april;17. maj;30. maj;9. juni;10. juni
                2042;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                2043;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                2044;10. april;14. april;15. april;17. april;18. april;13. maj;26. maj;5. juni;6. juni
                2045;2. april;6. april;7. april;9. april;10. april;5. maj;18. maj;28. maj;29. maj
                2046;18. marts;22. marts;23. marts;25. marts;26. marts;20. april;3. maj;13. maj;14. maj
                2047;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                2048;29. marts;2. april;3. april;5. april;6. april;1. maj;14. maj;24. maj;25. maj
                2049;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                2050;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                2051;26. marts;30. marts;31. marts;2. april;3. april;28. april;11. maj;21. maj;22. maj
                2052;14. april;18. april;19. april;21. april;22. april;17. maj;30. maj;9. juni;10. juni
                2053;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                2054;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                2055;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                2056;26. marts;30. marts;31. marts;2. april;3. april;28. april;11. maj;21. maj;22. maj
                2057;15. april;19. april;20. april;22. april;23. april;18. maj;31. maj;10. juni;11. juni
                2058;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                2059;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                2060;11. april;15. april;16. april;18. april;19. april;14. maj;27. maj;6. juni;7. juni
                2061;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                2062;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                2063;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                2064;30. marts;3. april;4. april;6. april;7. april;2. maj;15. maj;25. maj;26. maj
                2065;22. marts;26. marts;27. marts;29. marts;30. marts;24. april;7. maj;17. maj;18. maj
                2066;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                2067;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                2068;15. april;19. april;20. april;22. april;23. april;18. maj;31. maj;10. juni;11. juni
                2069;7. april;11. april;12. april;14. april;15. april;10. maj;23. maj;2. juni;3. juni
                2070;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                2071;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                2072;3. april;7. april;8. april;10. april;11. april;6. maj;19. maj;29. maj;30. maj
                2073;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                2074;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                2075;31. marts;4. april;5. april;7. april;8. april;3. maj;16. maj;26. maj;27. maj
                2076;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                2077;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                2078;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                2079;16. april;20. april;21. april;23. april;24. april;19. maj;1. juni;11. juni;12. juni
                2080;31. marts;4. april;5. april;7. april;8. april;3. maj;16. maj;26. maj;27. maj
                2081;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                2082;12. april;16. april;17. april;19. april;20. april;15. maj;28. maj;7. juni;8. juni
                2083;28. marts;1. april;2. april;4. april;5. april;30. april;13. maj;23. maj;24. maj
                2084;19. marts;23. marts;24. marts;26. marts;27. marts;21. april;4. maj;14. maj;15. maj
                2085;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                2086;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                2087;13. april;17. april;18. april;20. april;21. april;16. maj;29. maj;8. juni;9. juni
                2088;4. april;8. april;9. april;11. april;12. april;7. maj;20. maj;30. maj;31. maj
                2089;27. marts;31. marts;1. april;3. april;4. april;29. april;12. maj;22. maj;23. maj
                2090;9. april;13. april;14. april;16. april;17. april;12. maj;25. maj;4. juni;5. juni
                2091;1. april;5. april;6. april;8. april;9. april;4. maj;17. maj;27. maj;28. maj
                2092;23. marts;27. marts;28. marts;30. marts;31. marts;25. april;8. maj;18. maj;19. maj
                2093;5. april;9. april;10. april;12. april;13. april;8. maj;21. maj;31. maj;1. juni
                2094;28. marts;1. april;2. april;4. april;5. april;30. april;13. maj;23. maj;24. maj
                2095;17. april;21. april;22. april;24. april;25. april;20. maj;2. juni;12. juni;13. juni
                2096;8. april;12. april;13. april;15. april;16. april;11. maj;24. maj;3. juni;4. juni
                2097;24. marts;28. marts;29. marts;31. marts;1. april;26. april;9. maj;19. maj;20. maj
                2098;13. april;17. april;18. april;20. april;21. april;16. maj;29. maj;8. juni;9. juni
                2099;5. april;9. april;10. april;12. april;13. april;8. maj;21. maj;31. maj;1. juni";

            _testData = new List<TestElement>();
            foreach (var s in shiftingHolidays.Split(Environment.NewLine.ToCharArray())
                .Where(e => !string.IsNullOrEmpty(e)).Select(e => e.Trim()))
                _testData.Add(GetTestElement(s));

            _testData.Sort((x, y) => x.Year.CompareTo(y.Year));
        }

        [TestMethod]
        public void Test_HoliDays()
        {
            for (var testYear = 1950; testYear < 2100; testYear++)
            {
                Debug.WriteLine("Test year {0}", testYear);
                var testList = _testData.First(e => e.Year == testYear);
                Assert.IsTrue(testList == new Holidays<Danish>(testYear, false));
            }
        }

        [TestMethod]
        public void Test_SunDays()
        {
            for (var testYear = 1950; testYear < 2100; testYear++)
            {
                var holidaylist = new Holidays<Danish>(testYear, true, false);
                var element = holidaylist.First();
                Assert.IsTrue(element.Date.Day <= 7);

                element = holidaylist.Last();
                Assert.IsTrue(element.Date.Day <= 31);
                Assert.IsTrue(element.Date.Day >= 31 - 6);

                Debug.WriteLine("Test year {0}", testYear);

                foreach (var holiday in holidaylist)
                {
                    Assert.IsTrue(holiday.Date.DayOfWeek == DayOfWeek.Sunday);
                    Assert.IsTrue(holiday.Date.Year == testYear);
                }
            }
        }

        public class TestElement : IEquatable<Holidays<Danish>>
        {
            public TestElement(int year, List<Holiday> holidays)
            {
                Year = year;
                Holidays = holidays;
            }

            public int Year { get; }
            public List<Holiday> Holidays { get; }

            public bool Equals(Holidays<Danish> other)
            {
                var result = true;

                foreach (var holiday in other)
                    result &= Holidays.Exists(e => e.Date == holiday.Date && e.NativeName == holiday.NativeName);

                return result;
            }

            protected bool Equals(TestElement other)
            {
                return Year == other.Year && Equals(Holidays, other.Holidays);
            }

            public override bool Equals(object obj)
            {
                if (obj is null)
                    return false;

                if (ReferenceEquals(this, obj))
                    return true;

                if (obj.GetType() != GetType())
                    return false;

                return Equals((TestElement) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Year * 397) ^ (Holidays != null ? Holidays.GetHashCode() : 0);
                }
            }

            public static bool operator ==(TestElement x, Holidays<Danish> y) => x?.Equals(y) == true;

            public static bool operator !=(TestElement x, Holidays<Danish> y) => x?.Equals(y) == false;
        }
    }
}