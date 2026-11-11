@echo off
cd /d "%~dp0"
dotnet publish ElectronicsStore\ElectronicsStore.csproj -c Release -r win-x64 --self-contained true -o publish
pause
