unit BaseNationalHolidaysU;

interface

uses
  System.Generics.Collections, System.Generics.Defaults, System.DateUtils,

  HolidayU;
{$M+}

type
  TNumber = (First = 1, Second = 2, Third = 3, Fourth = 4, Last = 5);

  TDay = (Monday = DayMonday, Tuesday = DayTuesday, Wednesday = DayWednesday, Thursday = DayThursday, Friday = DayFriday, Saturday = DaySaturday, Sunday = DaySunday);

  TMonth = (January = MonthJanuary, February = MonthFebruary, March = MonthMarch, April = MonthApril, May = MonthMay, June = MonthJune, July = MonthJuly, August = MonthAugust,
    September = MonthSeptember, October = MonthOctober, November = MonthNovember, December = MonthDecember);

  TDateTimeHelper = record helper for TDateTime
  public
    function AddDays(dx: Integer): TDateTime;
  end;

  TBaseNationalHolidaysClass = class of TBaseNationalHolidays;

  TBaseNationalHolidays = class abstract(TObjectList<THoliday>)
  strict private
    FYear: Integer;
    FOrthodoxEasterSunday: TDateTime;
    FOrthodox_GoodFriday: TDateTime;
    FOrthodox_WhitMonday: TDateTime;
    FOrthodox_EasterSunday: TDateTime;
    FOrthodox_HolySaturday: TDateTime;
    FOrthodox_Christmas_Day: TDateTime;
    FOrthodox_WhitSunday: TDateTime;
    FOrthodox_MaundyThursday: TDateTime;
    FOrthodox_AscensionDay: TDateTime;
    FOrthodox_EasterMonday: TDateTime;
    FEasterSunday: TDateTime;
    FMaundyThursday: TDateTime;
    FAscensionDay: TDateTime;
    FEasterMonday: TDateTime;
    FGoodFriday: TDateTime;
    FPalmSunday: TDateTime;
    FWhitMonday: TDateTime;
    FHolySaturday: TDateTime;
    FWhitSunday: TDateTime;
    FAshWdensday: TDateTime;
    FEpiphany: TDateTime;
    FChristmasDay: TDateTime;
    FNewYearsDay: TDateTime;
    FBoxingDay: TDateTime;
    FLaborDay: TDateTime;

    function EncodeDate(Year: Word; Month: TMonth; Day: Word): TDateTime; overload;
    function EncodeDate(Year: Word; Month: Word; Day: Word): TDateTime; overload;
  strict protected

    function GetEasterDay(Year: Word): TDateTime;
    function GetOrthodoxEaster(Year: Word): TDateTime;
    property Year: Integer Read FYear;

    property AshWdensday: TDateTime read FAshWdensday;
    property PalmSunday: TDateTime read FPalmSunday;
    property MaundyThursday: TDateTime read FMaundyThursday;
    property GoodFriday: TDateTime read FGoodFriday;
    property HolySaturday: TDateTime read FHolySaturday;
    property EasterSunday: TDateTime read FEasterSunday;
    property EasterMonday: TDateTime read FEasterMonday;
    property AscensionDay: TDateTime read FAscensionDay;
    property WhitSunday: TDateTime read FWhitSunday;
    property WhitMonday: TDateTime read FWhitMonday;

    property Orthodox_MaundyThursday: TDateTime read FOrthodox_MaundyThursday;
    property Orthodox_GoodFriday: TDateTime read FOrthodox_GoodFriday;
    property Orthodox_HolySaturday: TDateTime read FOrthodox_HolySaturday;
    property Orthodox_EasterSunday: TDateTime read FOrthodox_EasterSunday;
    property Orthodox_EasterMonday: TDateTime read FOrthodox_EasterMonday;
    property Orthodox_AscensionDay: TDateTime read FOrthodox_AscensionDay;
    property Orthodox_WhitSunday: TDateTime read FOrthodox_WhitSunday;
    property Orthodox_WhitMonday: TDateTime read FOrthodox_WhitMonday;
    property Orthodox_Christmas_Day: TDateTime read FOrthodox_Christmas_Day;

    property NewYearsDay: TDateTime read FNewYearsDay;
    property Epiphany: TDateTime read FEpiphany;
    property LaborDay: TDateTime read FLaborDay;
    property ChristmasDay: TDateTime read FChristmasDay;
    property BoxingDay: TDateTime read FBoxingDay;
  public
    constructor Create(aYear: Integer); reintroduce;
    function NthDayInMonth(const Number: TNumber; const Day: TDay; const Month: TMonth; const Year: Integer): TDateTime;
    function MakeHolydays: TBaseNationalHolidays; virtual; abstract;
    function SundayName: string; virtual; abstract;
    function Add(aDate: TDateTime; aNativeName: String; aEnglishName: string = ''): THoliday; overload;
    function Add(aYear: Integer; aMonth: TMonth; aDay: Integer; aNativeName: string; aEnglishName: string = ''): THoliday; overload;
    function Add(aNumber: TNumber; aDay: TDay; aMonth: TMonth; aYear: Word; aNativeName: String; aEnglishName: string = ''): THoliday; overload;

    function GetWeekDay(aDate: TDateTime): TDay; overload;
    function GetWeekDay(aYear: Integer; aMonth: TMonth; aDay: Integer): TDay; overload;
    function GetWeekDay(aNumber: TNumber; aDay: TDay; aMonth: TMonth; aYear: Word): TDay; overload;

    function GetDate(aYear: Integer; aMonth: TMonth; aDay: Integer): TDateTime;
  end;

implementation

uses
  System.SysUtils, System.Math;

{ TBaseNationalHolidays }

function TBaseNationalHolidays.Add(aDate: TDateTime; aNativeName, aEnglishName: string): THoliday;
begin
  Result := THoliday.Create(aDate, aNativeName, aEnglishName);
  inherited Add(Result);
end;

function TBaseNationalHolidays.Add(aYear: Integer; aMonth: TMonth; aDay: Integer; aNativeName, aEnglishName: string): THoliday;
begin
  Result := Add(EncodeDate(aYear, aMonth, aDay), aNativeName, aEnglishName);
end;

function TBaseNationalHolidays.Add(aNumber: TNumber; aDay: TDay; aMonth: TMonth; aYear: Word; aNativeName, aEnglishName: string): THoliday;
begin
  Result := Add(NthDayInMonth(aNumber, aDay, aMonth, aYear), aNativeName, aEnglishName);
end;

constructor TBaseNationalHolidays.Create(aYear: Integer);
begin
  inherited Create;
  FYear := aYear;

  FOrthodoxEasterSunday := GetOrthodoxEaster(Year);

  FOrthodox_MaundyThursday := IncDay(FOrthodoxEasterSunday, -3);
  FOrthodox_GoodFriday := IncDay(FOrthodoxEasterSunday, -2);
  FOrthodox_HolySaturday := IncDay(FOrthodoxEasterSunday, -1);
  FOrthodox_EasterMonday := IncDay(FOrthodoxEasterSunday, 1);
  FOrthodox_AscensionDay := IncDay(FOrthodoxEasterSunday, 39);
  FOrthodox_WhitSunday := IncDay(FOrthodoxEasterSunday, 49);
  FOrthodox_WhitMonday := IncDay(FOrthodoxEasterSunday, 50);
  FOrthodox_Christmas_Day := EncodeDateDay(Year, 7);

  FEasterSunday := GetEasterDay(Year);
  FAshWdensday := IncDay(FEasterSunday, -46);
  FPalmSunday := IncDay(FEasterSunday, -7);
  FMaundyThursday := IncDay(FEasterSunday, -3);
  FGoodFriday := IncDay(FEasterSunday, -2);
  FHolySaturday := IncDay(FEasterSunday, -1);
  FEasterMonday := IncDay(FEasterSunday, 1);
  FAscensionDay := IncDay(FEasterSunday, 39);
  FWhitMonday := IncDay(FEasterSunday, 50);
  FWhitSunday := IncDay(FEasterSunday, 49);

  FEpiphany := EncodeDate(Year, TMonth.January, 6);
  FChristmasDay := EncodeDate(Year, TMonth.December, 25);
  FNewYearsDay := EncodeDate(Year, TMonth.January, 1);
  FBoxingDay := EncodeDate(Year, TMonth.December, 26);
  FLaborDay := EncodeDate(Year, TMonth.May, 1);
end;

function TBaseNationalHolidays.EncodeDate(Year, Month, Day: Word): TDateTime;
begin
  Result := System.SysUtils.EncodeDate(Year, Month, Day);
end;

function TBaseNationalHolidays.EncodeDate(Year: Word; Month: TMonth; Day: Word): TDateTime;
begin
  Result := System.SysUtils.EncodeDate(Year, Integer(Month), Day);
end;

function TBaseNationalHolidays.GetDate(aYear: Integer; aMonth: TMonth; aDay: Integer): TDateTime;
begin
  Result := EncodeDate(aYear, aMonth, aDay)
end;

function TBaseNationalHolidays.GetEasterDay(Year: Word): TDateTime;
(*
  This algorithm is based in part on the algorithm of Oudin (1940) as quoted in
  "Explanatory Supplement to the Astronomical Almanac", P. Kenneth Seidelmann.

  G is the Golden Number-1
  H is 23-Epact (modulo 30)
  I is the number of days from 21 March to the Paschal full moon
  J is the weekday for the Paschal full moon (0=Sunday, 1=Monday, etc.)
  L is the number of days from 21 March to the Sunday on or before the Paschal full moon (a number between -6 and 28)
  C is then Century
*)
var
  G, H, I, J, L, C: Integer;
  X, Y, Z: Integer; // Just for temporary use
  EasterDay, EasterMonth: Integer;
begin
  if Year = 0 then
    Year := FYear;

  G := Year mod 19;
  C := Year div 100;

  X := C div 4;
  Y := (8 * C + 13) div 25;
  Z := 19 * G;
  H := (C - X - Y + Z + 15) mod 30;

  X := H div 28;
  Y := 29 div (H + 1);
  Z := (21 - G) div 11;
  I := H - X * (1 - Y * Z);

  X := Year div 4;
  Y := C div 4;
  J := (Year + X + I + 2 - C + Y) mod 7;

  L := I - J;
  X := (L + 40) div 44;
  EasterMonth := 3 + X;

  X := EasterMonth div 4;
  EasterDay := L + 28 - 31 * X;

  Result := EncodeDate(Year, EasterMonth, EasterDay);
end;

function TBaseNationalHolidays.GetOrthodoxEaster(Year: Word): TDateTime;
var
  a, b, C, d, e, f: Integer;
  key, Month, Day: Integer;
begin
  a := Year mod 19;
  b := Year mod 7;
  C := Year mod 4;
  d := (19 * a + 16) mod 30;
  e := (2 * C + 4 * b + 6 * d) mod 7;
  f := (19 * a + 16) mod 30;

  key := f + e + 3;
  Month := IfThen(key > 30, 5, 4);
  Day := IfThen(key > 30, key - 30, key);
  Result := EncodeDate(Year, Month, Day);
end;

function TBaseNationalHolidays.GetWeekDay(aNumber: TNumber; aDay: TDay; aMonth: TMonth; aYear: Word): TDay;
begin
  Result := GetWeekDay(NthDayInMonth(aNumber, aDay, aMonth, aYear));
end;

function TBaseNationalHolidays.GetWeekDay(aYear: Integer; aMonth: TMonth; aDay: Integer): TDay;
begin
  Result := GetWeekDay(EncodeDate(aYear, aMonth, aDay));
end;

function TBaseNationalHolidays.GetWeekDay(aDate: TDateTime): TDay;
begin
  Result := TDay(DayOfTheWeek(aDate));
end;

function TBaseNationalHolidays.NthDayInMonth(const Number: TNumber; const Day: TDay; const Month: TMonth; const Year: Integer): TDateTime;
begin
  if Number = TNumber.Last then
  begin
    Result := IncDay(IncMonth(EncodeDate(Year, Integer(Month), 1), 1), -1);
    while DayOfTheWeek(Result) <> Integer(Day) do
      Result := IncDay(Result, -1);

    exit;
  end;

  Result := EncodeDate(Year, Integer(Month), 1);
  while DayOfTheWeek(Result) <> Integer(Day) do
    Result := IncDay(Result);

  Result := IncDay(Result, (Integer(Number) - 1) * DaysPerWeek);
end;

{ TDateTimeHelper }

function TDateTimeHelper.AddDays(dx: Integer): TDateTime;
begin
  Result := IncDay(Self, dx);
end;

end.
