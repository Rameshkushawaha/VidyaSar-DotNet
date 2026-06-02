@echo off
echo.
echo ========================================
echo    Scaffolding NEW Entities from DB
echo ========================================
echo.

set CONN_STR=Host=aws-1-ap-northeast-2.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.pdmkytftsosevauntaps;Password=Vidya@Sar123;SSL Mode=Require;Trust Server Certificate=true
set TEMP_DIR=src\VidyaSar.Infrastructure\ScaffoldedEntities
set ENTITY_DIR=src\VidyaSar.Domain\Entities

:: Step 1 - Scaffold to TEMP folder only
echo Step 1: Scaffolding to temp folder...
dotnet ef dbcontext scaffold "%CONN_STR%" Npgsql.EntityFrameworkCore.PostgreSQL ^
  --project src/VidyaSar.Infrastructure ^
  --startup-project src/VidyaSar.API ^
  --output-dir ScaffoldedEntities ^
  --context ScaffoldedDbContext ^
  --context-dir ScaffoldedContext ^
  --schema public ^
  --force ^
  --no-onconfiguring

echo.
echo Step 2: Copying ONLY new entity files (skipping existing)...

:: Step 2 - Copy only NEW files that don't exist in Domain/Entities
for %%f in (%TEMP_DIR%\*.cs) do (
    set "filename=%%~nxf"
    if not exist "%ENTITY_DIR%\%%~nxf" (
        echo   [NEW] Copying %%~nxf to Domain/Entities...
        copy "%%f" "%ENTITY_DIR%\%%~nxf" >nul

        :: Fix namespace in copied file
        powershell -Command "(Get-Content '%ENTITY_DIR%\%%~nxf') -replace 'namespace VidyaSar.Infrastructure;', 'namespace VidyaSar.Domain.Entities;' | Set-Content '%ENTITY_DIR%\%%~nxf'"
    ) else (
        echo   [SKIP] %%~nxf already exists - not overwriting
    )
)

echo.
echo Step 3: Cleaning up temp folder...
rmdir /s /q %TEMP_DIR% 2>nul
rmdir /s /q src\VidyaSar.Infrastructure\ScaffoldedContext 2>nul

echo.
echo ========================================
echo   Done! Only NEW tables were added.
echo   Existing entities untouched. 
echo ========================================
echo.
echo NEXT STEPS:
echo   1. Add DbSet for any new entities in AppDbContext.cs
echo   2. Run: dotnet build
echo.
pause