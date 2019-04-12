unit TablePrinterU;

interface

uses
  System.Classes,
  System.Generics.Collections,
  System.Console;

type
  ITablePrinter = interface
    procedure AddRow(const Values: array of const);
    procedure Print;
  end;

  TTablePrinter = class(TInterfacedObject, ITablePrinter)
  private const
    Seperator = #255;

  var
    FRows: TStringList;
    FValues: TStringList;
    FLengths: TList<Integer>;
    constructor Create(const args: array of string); reintroduce;
  public
    destructor Destroy; override;
    class function NewInstance(const args: array of string): ITablePrinter; reintroduce;
    procedure AddRow(const Values: array of const);
    procedure Print;
  end;

implementation

uses
  System.Sysutils;

{ TTablePrinter }

procedure TTablePrinter.AddRow(const Values: array of const);
var
  Row: string;
  Elements: TArray<string>;
  i: Integer;
begin
  if length(Values) <> FRows.Count then
    raise Exception.CreateFmt('Added row length [%d] is not equal to title row length [%d]', [length(Values), FRows.Count]);

  Row := string.Join(Seperator, Values);
  FValues.Add(Row);

  Elements := Row.Split([Seperator]);

  for i := 0 to FLengths.Count - 1 do
    if Elements[i].length > FLengths[i] then
      FLengths[i] := Elements[i].length;
end;

constructor TTablePrinter.Create(const args: array of string);
var
  arg: String;
begin
  FRows := TStringList.Create;
  FValues := TStringList.Create;
  FLengths := TList<Integer>.Create;
  for arg in args do
  begin
    FRows.Add(arg);
    FLengths.Add(length(arg));
  end;
end;

destructor TTablePrinter.Destroy;
begin
  FRows.Free;
  FValues.Free;
  FLengths.Free;
  inherited;
end;

class function TTablePrinter.NewInstance(const args: array of string): ITablePrinter;
begin
  Result := TTablePrinter.Create(args);
end;

procedure TTablePrinter.Print;
var
  i, j: Integer;
  Line, Row: string;
  Elements: TArray<string>;
begin
  j := 0;
  for i in FLengths do
  begin
    Line := '+-' + StringOfChar('-', i) + '-';
    Console.Write(Line);
    j := j + Line.length;
  end;
  Console.WriteLine('+');

  if j + 1 > Console.WindowWidth then
    Console.WindowWidth := j+2;

  Line := string.Empty;
  for i := 0 to FRows.Count - 1 do
    Line := Line + '| ' + FRows[i].PadRight(FLengths[i] + 1);

  Console.WriteLine(Line + '|');

  for i in FLengths do
    Console.Write('+-' + StringOfChar('-', i) + '-');
  Console.WriteLine('+');

  for Row in FValues do
  begin
    Line := string.Empty;
    Elements := Row.Split([Seperator]);
    for i := 0 to length(Elements) - 1 do
      if TryStrToInt(Elements[i], j) then
        Line := Line + '| ' + Elements[i].PadLeft(FLengths[i]) + ' ' // numbers are padded to the left
      else
        Line := Line + '| ' + Elements[i].PadRight(FLengths[i]) + ' ';

    Console.WriteLine(Line + '|');
  end;

  for i in FLengths do
    Console.Write('+-' + StringOfChar('-', i) + '-');
  Console.WriteLine('+');
end;

end.
