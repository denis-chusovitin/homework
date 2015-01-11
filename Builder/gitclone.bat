@echo off
if "%init%"=="" goto :EOF

echo Cloning repository...

git clone %gitURL% %pathRepository% >nul 2>%gitLog%

if ERRORLEVEL 1 goto :error

echo Cloning completed.
goto :EOF

:error
set cloneFail=true

echo Cloning failed.