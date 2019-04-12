unit HolidayU;

interface

{$M+}

Type
  THoliday = class(TInterfacedObject, IEquatable<THoliday>)
  private
    FNativeName: string;
    FEnglishName: string;
    FDate: TDateTime;
  published
    property NativeName: string read FNativeName;
    property EnglishName: string read FEnglishName;
    property Date: TDateTime read FDate;
  public
    constructor Create(aDate: TDateTime; aNativeName: string; aEnglishName: string = ''); reintroduce;
    function Equals(Value: THoliday): Boolean; reintroduce;
  end;

implementation

{ THoliday }

constructor THoliday.Create(aDate: TDateTime; aNativeName, aEnglishName: string);
begin
  FNativeName := aNativeName;
  FEnglishName := aEnglishName;

  if FEnglishName = '' then
    FEnglishName := aNativeName;

  FDate := aDate;
end;

function THoliday.Equals(Value: THoliday): Boolean;
begin
  Result := (Value <> nil) and (Value.Date = FDate) and (Value.EnglishName = EnglishName) and (Value.NativeName = NativeName);
end;

end.
