@echo off
echo.
echo ========================================
echo    Scaffolding Entities from Supabase
echo ========================================
echo.

set CONN_STR=Host=aws-1-ap-northeast-2.pooler.supabase.com;Port=6543;Database=postgres;Username=postgres.pdmkytftsosevauntaps;Password=Vidya@Sar123;SSL Mode=Require;Trust Server Certificate=true

dotnet ef dbcontext scaffold "%CONN_STR%" Npgsql.EntityFrameworkCore.PostgreSQL ^
  --project src/VidyaSar.Infrastructure ^
  --startup-project src/VidyaSar.API ^
  --output-dir ../VidyaSar.Domain/Entities ^
  --context AppDbContext ^
  --context-dir Data ^
  --schema public ^
  --force ^
  --no-onconfiguring ^
  --use-database-names

echo.
echo Fixing namespaces in generated entities...

:: Fix wrong namespace in all generated entity files
powershell -Command "Get-ChildItem 'src\VidyaSar.Domain\Entities\*.cs' | ForEach-Object { (Get-Content $_.FullName) -replace 'namespace VidyaSar.Infrastructure;', 'namespace VidyaSar.Domain.Entities;' -replace 'namespace VidyaSar.Infrastructure.Data;', 'namespace VidyaSar.Domain.Entities;' | Set-Content $_.FullName }"

:: Fix wrong using in entity files
powershell -Command "Get-ChildItem 'src\VidyaSar.Domain\Entities\*.cs' | ForEach-Object { (Get-Content $_.FullName) -replace 'using VidyaSar.Infrastructure;', 'using VidyaSar.Domain.Entities;' | Set-Content $_.FullName }"

echo Namespaces fixed!
echo.

dotnet build

if %errorlevel% == 0 (
    echo ========================================
    echo    SUCCESS - Entities Updated!
    echo ========================================
) else (
    echo ========================================
    echo    FAILED - Check errors above
    echo ========================================
)
pause