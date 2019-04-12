unit DanishU;

interface

uses
  BaseNationalHolidaysU;

Type
  Dainsh = class sealed(TBaseNationalHolidays)
  public
    function MakeHolydays: TBaseNationalHolidays; override;
    function SundayName: string; override;
  end;

implementation

{ TDainsh }

function Dainsh.MakeHolydays: TBaseNationalHolidays;
begin
  Add(PalmSunday, 'Palmesøndag', 'Palm Sunday');
  Add(MaundyThursday, 'Skærtorsdag', 'Maundy Thursday');
  Add(GoodFriday, 'Langfredag', 'Good Friday');
  Add(EasterSunday, 'Påskedag', 'Easter Sunday');
  Add(EasterMonday, '2. Påskedag', 'Easter Monday');
  Add(EasterSunday.AddDays(26), 'Store Bededag', 'Prayer Day');
  Add(AscensionDay, 'Kristi Himmelfartsdag', 'Ascension Day');
  Add(WhitSunday, 'Pinsedag', 'Whit Sunday');
  Add(WhitMonday, '2. Pinsedag', 'Whit monday');

  // Static Holidays
  Add(NewYearsDay, 'Nytårsdag', 'New Year''s day');
  Add(Year, TMonth.June, 05, 'Grundlovsdag', 'Constitution Day');
  Add(ChristmasDay, 'Juledag', 'Christmas Day');
  Add(BoxingDay, '2. Juledag', 'Boxing Day');
  Exit(Self);
end;

function Dainsh.SundayName: string;
begin
  Result := 'Søndag';
end;

end.
