param (
    [string] $Dir
)

Get-ChildItem -Path $Dir -Filter '*.html' | Remove-Item