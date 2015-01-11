@echo off
set init=true

echo Starting...

call settings

call clean

call gitclone
if "%cloneFail%"=="true" (
	set body=Cloning failed.
	set file=%gitdLog%

	goto :mail
)

call builder
if "%buildFail%"=="true" (
	set body=Build failed.

	goto :mail
)

call iscorrect
if "%correctFail%"=="true" (
	set body=Required files not found.
)

:mail
call email

echo Done.