
[Setup]
AppName=HoleElevation
AppId={{89f46c75-b999-4a28-bb63-dc776b2a3170}
AppVersion=1.0.0.1651771189
DefaultDirName={userappdata}/Autodesk/Revit/Addins/2019\HoleElevation
UsePreviousAppDir=no
PrivilegesRequired=lowest
OutputBaseFilename=HoleElevation_1.0.0.1651771189
DisableDirPage=yes

[Files]
Source: "C:\Users\nikitenkoaa\AppData\Local\Temp\RxBim_build_82a4a6b6-01ab-43cc-9eff-0f0d418623d4\bin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs; 
Source: "C:\Users\nikitenkoaa\AppData\Local\Temp\RxBim_build_82a4a6b6-01ab-43cc-9eff-0f0d418623d4\*"; DestDir: "{userappdata}/Autodesk/Revit/Addins/2019"; 

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
