param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../../"

Write-Host "********* BUILDING DbMigrator *********" -ForegroundColor Green
$dbMigratorFolder = Join-Path $slnFolder "src/Qa6185.DbMigrator"
Set-Location $dbMigratorFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/qa6185-db-migrator:$version .

Write-Host "********* BUILDING Web Application *********" -ForegroundColor Green
$webFolder = Join-Path $slnFolder "src/Qa6185.Web"
Set-Location $webFolder
dotnet publish -c Release
docker build -f Dockerfile.local -t mycompanyname/qa6185-web:$version .


### ALL COMPLETED
Write-Host "COMPLETED" -ForegroundColor Green
Set-Location $currentFolder