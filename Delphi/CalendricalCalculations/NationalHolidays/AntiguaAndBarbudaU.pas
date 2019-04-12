unit AntiguaAndBarbudaU;

interface

uses
  BaseNationalHolidaysU;

type
  AntiguaAndBarbuda = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ AntiguaAndBarbuda }

function AntiguaAndBarbuda.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(GoodFriday, 'Good Friday');
  Add(EasterMonday, 'Easter Monday');
  Add(Year, TMonth.May, 6, 'Labour Day');
  Add(WhitMonday, 'Whit Monday');
  Add(Year, TMonth.August, 5, 'J''Ouvert');
  Add(Year, TMonth.August, 6, 'Last Lap');
  Add(Year, TMonth.November, 1, 'Independence Day');
  Add(Year, TMonth.December, 9, 'V.C. Bird Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'Boxing Day');
end;

function AntiguaAndBarbuda.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
    * If January 1st falls on a Sunday, then the following Monday shall be a public holiday.
    * If Christmas Day falls on a Saturday, then the following Monday shall be a public holiday.  If Christmas Day falls on a Sunday, then the following Monday and Tuesday shall be public holidays.
    * Sundays, Christmas Day and Good Friday are observed as Common Law Holidays.
*)
end.
