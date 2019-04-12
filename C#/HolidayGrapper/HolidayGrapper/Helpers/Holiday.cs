using System;

namespace HolidayGrapper.Helpers
{
    public class Holiday : IEquatable<Holiday>
    {
        public string NativeName { get; }
        public string EnglishName { get; }
        public DateTime Date { get; }
        public Holiday(DateTime date, string nativeName, string englishName = "")
        {
            NativeName = nativeName;
            EnglishName = string.IsNullOrEmpty(englishName) ? nativeName : englishName;
            Date = date;
        }
        public bool Equals(Holiday other) => other?.Date == Date && other.EnglishName == EnglishName && other.NativeName == NativeName;
        public Holiday Clone() => new Holiday(Date, NativeName, EnglishName);
    }

}
