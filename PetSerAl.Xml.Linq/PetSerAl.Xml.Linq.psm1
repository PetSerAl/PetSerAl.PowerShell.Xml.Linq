Set-StrictMode -Version Latest
New-Alias -Name XName                      -Value Get-XName
New-Alias -Name XNamespace                 -Value Get-XNamespace
New-Alias -Name XAttribute                 -Value New-XAttribute
New-Alias -Name XCData                     -Value New-XCData
New-Alias -Name XComment                   -Value New-XComment
New-Alias -Name XDeclaration               -Value New-XDeclaration
New-Alias -Name XDocument                  -Value New-XDocument
New-Alias -Name XElement                   -Value New-XElement
New-Alias -Name New-XProcessingInstruction -Value New-XProcessingInstruction
New-Alias -Name New-XText                  -Value New-XText
Export-ModuleMember -Alias * -Cmdlet * -Function @() -Variable @()
