unit ArmeniaU;

interface

uses
  BaseNationalHolidaysU;

type
  Armenia = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Armenia }

function Armenia.MakeHolydays: TBaseNationalHolidays;
var
  dt: TDateTime;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Year, TMonth.January, 2, 'New Year''s Holiday');
  Add(Year, TMonth.January, 3, 'New Year''s Holiday');
  Add(Year, TMonth.January, 4, 'New Year''s Holiday');
  Add(Year, TMonth.January, 5, 'Armenian Christmas Eve Day');
  Add(Epiphany, 'Armenian Christmas Day');
  Add(Year, TMonth.January, 28, 'National Army Day');
  Add(Year, TMonth.March, 8, 'Women''s Day');
  Add(EasterMonday, 'Easter Monday');
  Add(Year, TMonth.April, 24, 'Genocide Memorial Day');
  Add(LaborDay, 'Labor Day');
  Add(Year, TMonth.May, 9, 'Victory Day');
  Add(Year, TMonth.May, 28, 'Day of the First Republic');
  Add(Year, TMonth.July, 5, 'Constitution Day');

  dt := GetDate(Year, TMonth.September, 11);

  while (GetWeekDay(dt) <> TDay.Sunday) do
    dt := dt.AddDays(1);

  dt := dt.AddDays(1);

  Add(dt, 'Exaltation of the Holy Cross');
  Add(Year, TMonth.September, 21, 'Independence Day');
  Add(Year, TMonth.December, 31, 'New Year''s Eve');
end;

function Armenia.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
  * Merelots are the days after five major festivals. They are days to honour deceased relatives. They may be given as an additional holiday and compensated by a Saturday or Sunday
*)
end.
