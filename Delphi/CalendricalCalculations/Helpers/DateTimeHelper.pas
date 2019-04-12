unit DateTimeHelper;

interface

uses
  System.SysUtils;

Type
  TDateTimeHelper = record helper for TDateTime
  public
    function ToLongDateString: string;
  end;

implementation

{ TDateTimeHelper }

function TDateTimeHelper.ToLongDateString: string;
begin
  Result := FormatDateTime(FormatSettings.LongDateFormat, self);
end;

end.
