@echo off
if "%init%"=="" goto :EOF

echo Sending email...

%pathBlat%\blat.exe -subject "%subject%" -body "%body%" -to %mail% -attacht %file% 

if ERRORLEVEL 1 goto :error

echo Sending succeeded.
goto :EOF

:error
echo Error in sending.