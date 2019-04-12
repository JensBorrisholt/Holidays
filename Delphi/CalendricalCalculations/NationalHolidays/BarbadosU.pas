unit BarbadosU;

interface

uses
  BaseNationalHolidaysU;

type
  Barbados = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Barbados }

function Barbados.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Year, TMonth.January, 21, 'Errol Barrow Day');
  Add(GoodFriday, 'Good Friday');
  Add(EasterMonday, 'Easter Monday');
  Add(Year, TMonth.April, 29, 'National Heroes Day Holiday');
  Add(LaborDay, 'May Day');
  Add(WhitMonday, 'Whit Monday');
  Add(Year, TMonth.August, 1, 'Emancipation Day');
  Add(TNumber.First, TDay.Monday, TMonth.August, Year, 'Kadooment Day');
  Add(Year, TMonth.November, 30, 'Independence Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'Boxing Day');
end;

function Barbados.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
  * If the date of a bank holiday falls on a Sunday, it is generally moved to the following day
*)
end.
