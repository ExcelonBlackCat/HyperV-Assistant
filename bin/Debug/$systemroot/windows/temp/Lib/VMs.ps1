function CreateAD([string]$NDD,[string]$NetBios){
    Import-Module ADDSDeployment
    Install-ADDSForest `
    -CreateDnsDelegation:$false `
    -DatabasePath "C:\Windows\NTDS" `
    -DomainMode "WinThreshold" `
    -DomainName "$NDD" `
    -DomainNetbiosName "$NetBios" `
    -ForestMode "WinThreshold" `
    -InstallDns:$true `
    -LogPath "C:\Windows\NTDS" `
    -NoRebootOnCompletion:$false `
    -SysvolPath "C:\Windows\SYSVOL" `
    -Force:$true
}

function CreateDHCP([string]$StartIP,[string]$EndIP,[string]$MASK,[string]$GateWay,[string]$DNSIP,[string]$NDD,[string]$Nom){
    Install-WindowsFeature -Name dhcp -IncludeAllSubFeature -IncludeManagementTools
    Set-DhcpServerv4OptionValue -DnsServer "$DNSIP" -DnsDomain "$NDD"
    Add-DhcpServerv4Scope -Name "$Nom" -StartRange "$StartIP" -EndRange "$EndIP" -SubnetMask "$MASK" -Description "$Nom"
    $NetworkIP=ConvertTo-DottedDecimalIP ((ConvertTo-DecimalIP $StartIP) -band (ConvertTo-DecimalIP $MASK))
    Set-DhcpServerv4OptionValue -ScopeId "$NetworkIP" -Router "$GateWay"
}