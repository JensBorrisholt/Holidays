using System;
using CalendricalCalculation;
using CalendricalCalculation.NationalHolidays;

namespace HolidayTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testYear = new Random().Next(1950, 2099);
            var holidays = new Holidays<Usa>(testYear, false, true);

            var tablePrinter = new TablePrinter("Date", "Native name", "English name");

            foreach (var element in holidays)
                tablePrinter.AddRow(element.Date.ToLongDateString(), element.NativeName, element.EnglishName);

            tablePrinter.Print();
            Console.ReadLine();
        }
    }
}
