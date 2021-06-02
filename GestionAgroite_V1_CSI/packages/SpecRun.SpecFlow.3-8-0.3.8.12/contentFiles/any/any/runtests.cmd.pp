@pushd %~dp0

@echo %~dp0

cd ./SpecFlowPlusRunner/net461

@set profile=%1
@if "%profile%" == "" set profile=Default

@if exist "%~dp0/%profile%.srprofile" (
    "%~dp0/SpecFlowPlusRunner/net461/SpecRun.exe" run "%profile%.srprofile" --baseFolder "../.." %2 %3 %4 %5
) else (
    "%~dp0/SpecFlowPlusRunner/net461/SpecRun.exe" run --baseFolder "../.." %2 %3 %4 %5
)

:end

@popd
