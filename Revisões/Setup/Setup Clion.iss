[Dirs]
Name: {app}\Report
Name: {app}\Data
Name: {app}\Icons
Name: {app}\Image
Name: {app}\Software
[Files]
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Report\Rpt_Reci.rpt; DestDir: {app}\Report\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Report\Rpt_Reci.vb; DestDir: {app}\Report\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Report\Rpt_Rere.rpt; DestDir: {app}\Report\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Report\Rpt_Rere1.vb; DestDir: {app}\Report\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\CliOn.exe; DestDir: {app}
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Interop.ADODB.dll; DestDir: {app}
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Data\Data.mdb; DestDir: {app}\Data\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Icons\icon.ico; DestDir: {app}\Icons\
Source: C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Image\Logo.jpg; DestDir: {app}\Image\
[Setup]
InternalCompressLevel=ultra64
OutputBaseFilename=Clion Setup
SolidCompression=true
VersionInfoVersion=1.0.0
VersionInfoCompany=4U Soft
VersionInfoCopyright=4u Soft
Compression=lzma/ultra64
VersionInfoProductName=Clion - gerenciador de Clientes
VersionInfoProductVersion=1.0.0
AppCopyright=4U Soft
AppName=Clion
AppVerName=1.0.0
LicenseFile=
DisableStartupPrompt=true
WizardImageBackColor=clGreen
DefaultDirName={pf}\Clion
AllowRootDirectory=true
AllowNoIcons=true
ShowLanguageDialog=yes
SetupIconFile=C:\Users\user\SkyDrive\Desenvolvimento\CliOn\CliOn Gerenciadr de Clientes\Revisões\Final\Icons\icon.ico
DefaultGroupName=Clion
EnableDirDoesntExistWarning=true
DirExistsWarning=yes
[Icons]
Name: {group}\CliOn; Filename: {app}\CliOn.exe; WorkingDir: {app}; Comment: CliOn; IconFilename: {app}\CliOn.exe; IconIndex: 0
Name: {userdesktop}\CliOn; Filename: {app}\CliOn.exe; WorkingDir: {app}; Comment: CliOn; IconFilename: {app}\CliOn.exe; IconIndex: 0
