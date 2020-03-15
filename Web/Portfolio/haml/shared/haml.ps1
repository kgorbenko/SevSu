param(
    [string] $Dir,
    [string] $Globals
)

$pages = @(
    'index',
    'about',
    'interests',
    'learning',
    'photos',
    'contact',
    'test',
    'history'
)

try {
    $pages | ForEach-Object {
        Write-Host "Processing $_.haml file."

        $hamlFilePath = Join-Path $Dir "$_.haml"
        $htmlFilePath = Join-Path $Dir "$_.html"
        $command = "haml -r $Globals $hamlFilePath $htmlFilePath"
        
        Write-Host "Executing command `n$command"

        Invoke-Expression $command
        if (-not $?) { throw "An error occured during executing command $command." }

        Write-Host "Command successfully executed. Output file is $htmlFilePath."
    }
    exit 0
} catch {
    Write-Error $_.Exception.Message
    exit 1
}