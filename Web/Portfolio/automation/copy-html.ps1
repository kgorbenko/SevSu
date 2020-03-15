param (
    [string] $Source,
    [string] $Destination
)

try {
    $htmlFiles = Get-ChildItem -Path $Source -Filter '*.html'
    if (-not $?) { throw 'An error occured during getting html files.' }
    if ($htmlFiles.Count -eq 0) {
        Write-Host "No html files found in $Source directory."
        exit 0
    }
    Write-Host "Found $($htmlFiles.Count) html files. Starting copy."

    if (-not (Test-Path $Destination -PathType Container)) {
        Write-Host "Creating $Destination directory."
        New-Item $Destination -ItemType Directory
        if (-not $?) { throw "An error occured during creating $Destination directory."}
        else { Write-Host "$Destination directory successfully created."}
    }

    $htmlFiles | ForEach-Object {
        Write-Host "Copying $_ from $Source to $Destination."
        Copy-Item $_.FullName -Destination $Destination
        if (-not $?) { throw "An error occured during copy of $_ from $Source to $Destination." }
        Write-Host 'File copy finished.'
    }
    exit 0
} catch {
    Write-Error $_.Exception.Message
    exit 1
}