unit ArgentinaU;

interface

uses
  BaseNationalHolidaysU;

type
  Argentina = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Argentina }

function Argentina.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(AshWdensday.AddDays(-2), 'Carnival Monday');
  Add(AshWdensday.AddDays(-1), 'Carnival Tuesday');
  Add(Year, TMonth.March, 24, 'Truth and Justice Memorial Day');
  Add(Year, TMonth.April, 2, 'Malvinas Day');
  Add(GoodFriday, 'Good Friday');
  Add(LaborDay, 'Labour Day');
  Add(Year, TMonth.May, 25, 'May Day Revolution');

  if Year > 2016 then
    Add(Year, TMonth.June, 17, 'Martin Miguel de Guemes Day');

  Add(Year, TMonth.June, 20, 'National Flag Day');
  Add(Year, TMonth.July, 8, 'Public Holiday');
  Add(Year, TMonth.July, 9, 'Independence Day');

  Add(TNumber.Third, TDay.Monday, TMonth.August, Year, 'St. Martin''s Day');
  Add(Year, TMonth.October, 12, 'Day of respect for cultural diversity');
  Add(TNumber.Fourth, TDay.Monday, TMonth.November, Year, 'Day of National Sovereignty');

  Add(Year, TMonth.December, 8, 'Immaculate Conception Day');
  Add(ChristmasDay, 'Christmas Day');
end;

function Argentina.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
  * If the date falls on a Wednesday, the holiday is the preceding Monday. If it falls on a Thursday then the holiday is the following Monday.
  * If the holiday is on Tuesday, Monday is added as a holiday day. if the holiday is on Thursday, then Friday is granted as holiday.
  * The rules above can lead to a lot of annual Public holidays, but most Argentinians only get 10 vacation days, rising to 15 days if they have worked for more than 5 years in a company.
*)
end.
