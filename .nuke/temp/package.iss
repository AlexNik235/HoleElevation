
[Setup]
AppName=HoleElevation
AppId={{89f46c75-b999-4a28-bb63-dc776b2a3170}
AppVersion=1.0.0.1652651745
DefaultDirName={userappdata}/Autodesk/Revit/Addins/2020\HoleElevation
UsePreviousAppDir=no
PrivilegesRequired=lowest
OutputBaseFilename=HoleElevation_1.0.0.1652651745
DisableDirPage=yes

[Files]
Source: "C:\Users\Undea\AppData\Local\Temp\RxBim_build_008ee357-64d0-4f7c-aa94-0dc0968fa434\bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs; 
Source: "C:\Users\Undea\AppData\Local\Temp\RxBim_build_008ee357-64d0-4f7c-aa94-0dc0968fa434\*"; DestDir: "{userappdata}/Autodesk/Revit/Addins/2020"; 

[Code]
function GetUninstallString(): String;
var
  sUnInstPath: String;
  sUnInstallString: String;
begin
  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppId")}_is1');

  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;

function IsUpgrade(): Boolean;
begin
  Result := (GetUninstallString() <> '');
end;

function UnInstallOldVersion(): Integer;
var
  sUnInstallString: String;
  iResultCode: Integer;
begin
{ Return Values: }
{ 1 - uninstall string is empty }
{ 2 - error executing the UnInstallString }
{ 3 - successfully executed the UnInstallString }

  { default return value }
  Result := 0;

  { get the uninstall string of the old app }
  sUnInstallString := GetUninstallString();
  if sUnInstallString <> '' then begin
    sUnInstallString := RemoveQuotes(sUnInstallString);
    if Exec(sUnInstallString, '/SILENT /NORESTART /SUPPRESSMSGBOXES','', SW_HIDE, ewWaitUntilTerminated, iResultCode) then
      Result := 3
    else
      Result := 2;
  end else
    Result := 1;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if (CurStep=ssInstall) then
  begin
    if (IsUpgrade()) then
    begin
      UnInstallOldVersion();
    end;
  end;
end;
