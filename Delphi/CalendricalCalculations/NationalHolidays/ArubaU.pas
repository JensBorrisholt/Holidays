unit ArubaU;

interface

uses
  BaseNationalHolidaysU;

type
  Aruba = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation
{ Aruba }

function Aruba.MakeHolydays: TBaseNationalHolidays;
var
  dt: TDateTime;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Year, TMonth.January, 25, 'Betico Croes Day');
  Add(Year, TMonth.March, 4, 'Carnival Monday');
  Add(Year, TMonth.March, 18, 'National Anthem and Flag Day');
  Add(GoodFriday, 'Good Friday');
  Add(EasterMonday, 'Easter Monday');

  dt := GetDate(Year, TMonth.April, 27);
  if GetWeekDay(dt) = TDay.Sunday then
     dt := dt.AddDays(-1);
  Add(dt, 'King''s Birthday'); //If 27th is a Sunday, celebrations are held on 26th

  Add(LaborDay, 'Labour Day');
  Add(AscensionDay, 'Ascension Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'Boxing Day');
end;

function Aruba.SundayName: string;
begin
  Result := 'Sunday';
end;

end.
