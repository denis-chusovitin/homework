@echo off
if "%init%"=="" goto :EOF

echo Checking build...

for /F "tokens=*" %%a in (%paths%) do (
	if not exist %pathRepository%\%%a (
		set correctFail=true
		echo Not found: %%a
	)
)

echo Build is correct.