@echo off
if "%init%"=="" goto :EOF

echo Removing the old repository...

if exist %pathRepository% goto :clean

echo Old repository not found.
goto :EOF

:clean
rmdir /s /q %pathRepository%

echo Removal completed.