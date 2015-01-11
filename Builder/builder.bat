@echo off
if "%init%"=="" goto :EOF

echo Building solution...

%pathMSBuild%\MSBuild.exe %pathRepository%\%solution% /p:configuration=Release;VisualStudioVersion=12.0 >%buildLog%

if ERRORLEVEL 1 goto :error

echo Build completed.
goto :EOF

:error
set buildFail=true
echo Build failed.