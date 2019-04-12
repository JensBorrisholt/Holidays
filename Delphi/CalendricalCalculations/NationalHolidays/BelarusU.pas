unit BelarusU;

interface

uses
  BaseNationalHolidaysU;

type
  Belarus = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Belarus }

function Belarus.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Orthodox_Christmas_Day, 'Orthodox Christmas Day');
  Add(Year, TMonth.March, 8, 'Women''s Day');
  Add(LaborDay, 'Labour Day');
  Add(Year, TMonth.May, 7, 'Commemoration Day');
  Add(Year, TMonth.May, 9, 'Victory Day');
  if Year > 1944 then
    Add(Year, TMonth.July, 3, 'Independence Day'); // Liberation of Belarus from the Nazis in 1944

  if Year > 1917 then // Commemorates the Russian Revolution of 1917
    Add(Year, TMonth.November, 7, 'October Revolution Day');

  Add(Year, TMonth.December, 24, 'Christmas Eve');
  Add(ChristmasDay, 'Christmas Day (Catholic)');
end;

function Belarus.SundayName: string;
begin
  Result := 'Sunday';
end;

end.
