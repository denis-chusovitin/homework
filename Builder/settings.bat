@echo off
if "%init%"=="" goto :EOF

set pathMsBuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319
set pathRepository=C:\Repository
set pathBlat=C:\Blat

set gitURL=https://github.com/denis-chusovitin/BuilderTask

set solution=BuilderTask.sln 
set buildLog=msbuild.log 
set gitLog=gitLog.log
set paths=paths.txt

set buildFail=false
set cloneFail=false
set correctFail=false

set mail=chusovitn.den@gmail.com
set body=Successfully built.
set subject=Builder log
set file=%buildLog%