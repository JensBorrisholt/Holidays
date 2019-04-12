program Holidays_Demo;

{$APPTYPE CONSOLE}
{$R *.res}

uses
  System.SysUtils,
  System.Console,
  System.Math,
  BaseNationalHolidaysU in 'CalendricalCalculations\BaseNationalHolidaysU.pas',
  HolidaysU in 'CalendricalCalculations\HolidaysU.pas',
  HolidayU in 'CalendricalCalculations\HolidayU.pas',
  DanishU in 'CalendricalCalculations\NationalHolidays\DanishU.pas',
  DateTimeHelper in 'CalendricalCalculations\Helpers\DateTimeHelper.pas',
  TablePrinterU in 'TablePrinterU.pas',
  AnguillaU in 'CalendricalCalculations\NationalHolidays\AnguillaU.pas',
  AntiguaAndBarbudaU in 'CalendricalCalculations\NationalHolidays\AntiguaAndBarbudaU.pas',
  ArgentinaU in 'CalendricalCalculations\NationalHolidays\ArgentinaU.pas',
  ArmeniaU in 'CalendricalCalculations\NationalHolidays\ArmeniaU.pas',
  ArubaU in 'CalendricalCalculations\NationalHolidays\ArubaU.pas',
  AustriaU in 'CalendricalCalculations\NationalHolidays\AustriaU.pas',
  BahamasU in 'CalendricalCalculations\NationalHolidays\BahamasU.pas',
  BarbadosU in 'CalendricalCalculations\NationalHolidays\BarbadosU.pas',
  BelarusU in 'CalendricalCalculations\NationalHolidays\BelarusU.pas';

var
  TablePrinter: ITablePrinter;
  TestYear: Integer;
  Holidays: IHolidays;
  Element: THoliDay;
begin
  try
    randomize;
    TestYear := RandomRange(1950, 2099);
    Holidays := THolidays<Dainsh>.Construct(TestYear, false, true);

    TablePrinter := TTablePrinter.NewInstance(['Date', 'Native name', 'English name']);

    for Element in Holidays do
      TablePrinter.AddRow([Element.Date.ToLongDateString, Element.NativeName, Element.EnglishName]);

    TablePrinter.Print;

    Console.WriteLine(string.Empty);

    Holidays := THolidays<Anguilla>.Construct(TestYear, false, true);

    TablePrinter := TTablePrinter.NewInstance(['Date', 'Native name', 'English name']);

    for Element in Holidays do
      TablePrinter.AddRow([Element.Date.ToLongDateString, Element.NativeName, Element.EnglishName]);

    TablePrinter.Print;

    Console.ReadLine;
  except
    on E: Exception do
      Writeln(E.ClassName, ': ', E.Message);
  end;

end.
