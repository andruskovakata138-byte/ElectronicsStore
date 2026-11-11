@echo off
cd /d "%~dp0"
dotnet build ElectronicsStore.sln -c Release
if errorlevel 1 goto end
dotnet run --project Tests\PriceRulesTests.csproj
:end
pause
