unit AustriaU;

interface

uses
  BaseNationalHolidaysU;

type
  Austria = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ Austria }

function Austria.MakeHolydays: TBaseNationalHolidays;
begin
  Add(NewYearsDay, 'New Year''s Day');
  Add(Epiphany, 'Epiphany');
  Add(EasterMonday, 'Easter Monday');
  Add(LaborDay, 'Labour Day');
  Add(AscensionDay, 'Ascension Day');
  Add(WhitMonday, 'Whit Monday');
  Add(Year, TMonth.June, 20, 'Corpus Christi');
  Add(Year, TMonth.August, 15, 'Assumption Day');
  Add(Year, TMonth.October, 26, 'National Day');
  Add(Year, TMonth.November, 1, 'All Saints'' Day');
  Add(Year, TMonth.December, 8, 'Immaculate Conception Day');
  Add(ChristmasDay, 'Christmas Day');
  Add(BoxingDay, 'St. Stephen''s Day');
end;

function Austria.SundayName: string;
begin
  Result := 'Sunday';
end;

(*
  Notes
    * Holidays falling on Saturday and Sunday are not substituted by a weekday
*)
end.
