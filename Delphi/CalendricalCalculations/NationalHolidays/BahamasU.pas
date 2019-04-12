unit BahamasU;

interface

uses
  BaseNationalHolidaysU;

type
  Bahamas = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Bahamas }

function Bahamas.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Year, TMonth.January, 10, 'Majority Rule Day');
  Add(GoodFriday, 'Good Friday');
  Add(EasterMonday, 'Easter Monday');
  Add(Year, TMonth.June, 7, 'Randol Fawkes Labor Day');
  Add(WhitMonday, 'Whit Monday');
  Add(Year, TMonth.July, 10, 'Independence Day');
  Add(Year, TMonth.August, 5, 'Emancipation Day');
  Add(Year, TMonth.October, 14, 'National Heroes Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'Boxing Day');
end;

function Bahamas.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
    * Holidays that fall on a Saturday or Sunday are usually celebrated on the following Monday
    * Holidays that fall on Tuesday are usually celebrated on the previous Monday
    * Holidays that fall on a Wednesday or a Thursday are celebrated on the following Friday (with the exception of Independence Day, Christmas Day and Boxing Day)
    * Banks/businesses and many shops are closed on public holidays
*)
end.
