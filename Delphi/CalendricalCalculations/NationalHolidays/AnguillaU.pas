unit AnguillaU;

interface

uses
  BaseNationalHolidaysU;

type
  Anguilla = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Anguilla }

function Anguilla.MakeHolydays: TBaseNationalHolidays;
var
  dt: TDateTime;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Year, TMonth.March, 2, 'James Ronald Webster Day');
  Add(GoodFriday, 'Good Friday');
  Add(EasterMonday, 'Easter Monday');
  Add(LaborDay, 'Labour Day');
  Add(WhitMonday, 'Whit Monday');
  Add(Year, TMonth.May, 30, 'Anguilla Day');

  // Monday after second Saturday in June
  dt := NthDayInMonth(TNumber.Second, TDay.Saturday, TMonth.June, Year).AddDays(2);
  Add(dt, 'Celebration of the Birthday of Her Majesty the Queen');

  // First Monday of August
  dt := NthDayInMonth(TNumber.First, TDay.Monday, TMonth.August, Year);
  Add(dt, 'August Monday');
  // Thursday after first Monday of August
  Add(dt.AddDays(3), 'August Thursday');

  Add(Year, TMonth.August, 10, 'Constitution Day');
  Add(Year, TMonth.December, 19, 'National Heroes and Heroines Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'Boxing Day');
end;

function Anguilla.SundayName: string;
begin
  Result := 'Sunday';
end;

end.
