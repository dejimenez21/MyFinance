# Define variables
$tempPublishPath = "C:\Temp\MyFinance\Publish"
$iisAppPath = "C:\inetpub\wwwroot\Hosting\MyFinance\Api"
$backupConfigPath = "C:\Temp\MyFinance\Backup\web.config"

# Create directories if they don't exist
if (!(Test-Path -Path $tempPublishPath )) {
    New-Item -ItemType directory -Path $tempPublishPath
}

if (!(Test-Path -Path $iisAppPath )) {
    New-Item -ItemType directory -Path $iisAppPath
}

if (!(Test-Path -Path (Split-Path -Parent $backupConfigPath))) {
    New-Item -ItemType directory -Path (Split-Path -Parent $backupConfigPath)
}

# Step 1: Publish to temporary location
dotnet publish -c Release -o $tempPublishPath

# Step 2: Backup existing web.config if exists
if (Test-Path -Path "$iisAppPath\web.config") {
    Copy-Item -Path "$iisAppPath\web.config" -Destination $backupConfigPath -Force
}

# Step 3: Remove old files
Remove-Item -Path "$iisAppPath\*" -Recurse -Force

# Step 4: Copy new files to IIS application path
Copy-Item -Path "$tempPublishPath\*" -Destination $iisAppPath -Recurse -Force

# Step 5: Restore the web.config if backup exists
if (Test-Path -Path $backupConfigPath) {
    Copy-Item -Path $backupConfigPath -Destination "$iisAppPath\web.config" -Force
}