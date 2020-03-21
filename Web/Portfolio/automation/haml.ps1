$scriptFolder =  Split-Path $MyInvocation.MyCommand.Path
$scriptPath = Join-Path $scriptFolder 'parse-haml.ps1'

$projectFolder = Split-Path $scriptFolder
$hamlFolder = Join-Path $projectFolder 'haml'
$globalsFolder = Join-Path $projectFolder 'haml\shared\globals.rb'

& $scriptPath -Dir $hamlFolder -Globals $globalsFolder