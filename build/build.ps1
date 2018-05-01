$logo = (Invoke-WebRequest "https://raw.githubusercontent.com/FantasticFiasco/logo/master/logo.raw").toString();
Write-Host "$logo" -ForegroundColor Green

& nuget restore
& msbuild /logger:"C:\Program Files\AppVeyor\BuildAgent\Appveyor.MSBuildLogger.dll"

if ($LastExitCode -ne 0) { $host.SetShouldExit($LastExitCode)  }