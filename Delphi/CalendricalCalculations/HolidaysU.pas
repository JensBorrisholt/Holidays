unit HolidaysU;

interface

uses
  System.Generics.Collections, HolidayU, BaseNationalHolidaysU;

{$M+}

type
  IHolidays = interface
    function GetEnumerator: TEnumerator<THoliDay>;
  end;

  TInterfaceTEnumerable<T> = class(TEnumerable<T>)
  private const
    objDestroyingFlag = Integer($80000000);
    objDisposedFlag = Integer($40000000);
  var
    [Volatile]FRefCount: Integer;
    class procedure __MarkDestroying(const Obj); static; inline;
  protected
    function QueryInterface(const IID: TGUID; out Obj): HResult; stdcall;
    function _AddRef: Integer; stdcall;
    function _Release: Integer; stdcall;
  end;

  THolidays<T: TBaseNationalHolidays, constructor> = class(TInterfaceTEnumerable<THoliDay>, IHolidays)
  private
    FIncludeSundays: Boolean;
    FIncludeHolidays: Boolean;
    FYear: Integer;
    FHolyDayList: TBaseNationalHolidays;
    procedure MakeHolidays;
  protected
    function DoGetEnumerator: TEnumerator<THoliDay>; override;
  published
    property IncludeSundays: Boolean read FIncludeSundays;
    property IncludeHolidays: Boolean read FIncludeHolidays;
    property Year: Integer read FYear;
  public
    constructor Create(aYear: Integer = 0; aIncludeSundays: Boolean = True; aIncludeHolidays: Boolean = True); reintroduce;
    class function Construct(aYear: Integer = 0; aIncludeSundays: Boolean = True; aIncludeHolidays: Boolean = True): IHolidays;
  end;

implementation

uses
  System.Sysutils, System.DateUtils;
{ THolidays<T> }

constructor THolidays<T>.Create(aYear: Integer; aIncludeSundays, aIncludeHolidays: Boolean);
begin
  inherited Create;
  FYear := aYear;
  FIncludeSundays := aIncludeSundays;
  FIncludeHolidays := aIncludeHolidays;
  MakeHolidays;
end;

function THolidays<T>.DoGetEnumerator: TEnumerator<THoliDay>;
begin
  Result := FHolyDayList.GetEnumerator;
end;

procedure THolidays<T>.MakeHolidays;
var
  Sunday: TDateTime;
  LastSunday: TDateTime;
begin
  FHolyDayList := T(TBaseNationalHolidaysClass(T).Create(FYear));
  if FIncludeHolidays then
    FHolyDayList.MakeHolydays;

  if IncludeSundays then
  begin
    Sunday := FHolyDayList.NthDayInMonth(TNumber.First, TDay.Sunday, TMonth.January, Year);
    LastSunday := FHolyDayList.NthDayInMonth(TNumber.Last, TDay.Sunday, TMonth.December, Year);

    while Sunday <= LastSunday do
    begin
      FHolyDayList.Add(Sunday, FHolyDayList.SundayName);
      Sunday := IncDay(Sunday, DaysPerWeek);
    end;
  end;
end;

class function THolidays<T>.Construct(aYear: Integer; aIncludeSundays, aIncludeHolidays: Boolean): IHolidays;
begin
  Result := THolidays<T>.Create(aYear, aIncludeSundays, aIncludeHolidays);
end;


{ TInterfaceTEnumerable<T> }

function TInterfaceTEnumerable<T>.QueryInterface(const IID: TGUID;  out Obj): HResult;
begin
  if GetInterface(IID, Obj) then
    Result := 0
  else
    Result := E_NOINTERFACE;

end;

function TInterfaceTEnumerable<T>._AddRef: Integer;
begin
  Result := AtomicIncrement(FRefCount);
end;

function TInterfaceTEnumerable<T>._Release: Integer;
begin
  Result := AtomicDecrement(FRefCount);
  if Result = 0 then
  begin
    // Mark the refcount field so that any refcounting during destruction doesn't infinitely recurse.
    __MarkDestroying(Self);
    Destroy;
  end;
end;

class procedure TInterfaceTEnumerable<T>.__MarkDestroying(const Obj);
var
  LRef: Integer;
begin
  repeat
    LRef := TInterfaceTEnumerable<T>(Obj).FRefCount;
  until AtomicCmpExchange(TInterfaceTEnumerable<T>(Obj).FRefCount, LRef or objDestroyingFlag, LRef) = LRef;
end;

end.
