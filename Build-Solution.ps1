$scriptPath = Split-Path $MyInvocation.MyCommand.Path
$projFile = Join-Path $scriptPath DapperWrapper.msbuild

& "$(get-content env:windir)\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe" $projFile /p:Configuration=Release /t:Build