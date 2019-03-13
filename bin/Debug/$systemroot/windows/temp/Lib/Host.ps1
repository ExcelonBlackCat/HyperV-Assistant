#Var globale
$server = "\\ASRBD33DATA"
$serverPath = "$server\asrbd33\Fichier partagé\Powershell"
$installPath = "$server\install"
$systemRoot = get-content Env:\HOMEDRIVE
$clientPath = "$systemRoot\windows\Temp"
$start_time_script = Get-Date
$userName = Get-Content Env:\USERNAME
$localComputer = Get-Content Env:\COMPUTERNAME
$logsPath = "$server\Logs\$userName@$localComputer.log"

#Var Hyper-V
$VHDpath = "C:\Hyper-V\VHDs"
$VMpath = "C:\Hyper-V\VMs"
$Masterpath = "C:\Hyper-V\Master"
$ethernet = Get-NetAdapter -Name ethernet

function CreateVMSwitch($VMSwitchName, $Type){
	If (( !( Get-VMSwitch | Where {$_.Name -eq "$VMSwitchName"} )) -and ( $Type -eq "Private" ) ){
		New-VMSwitch -Name "$VMSwitchName" -SwitchType Private -Notes 'Internal VMs only'
        If($?){return 1}Else{return 0}
	}
	If (( !( Get-VMSwitch | Where {$_.Name -eq "$VMSwitchName"} )) -and ( $Type -eq "Internal" ) ){
		New-VMSwitch -Name "$VMSwitchName" -SwitchType Internal -Notes 'Parent OS, and internal VMs'
        If($?){return 1}Else{return 0}
	}
	If (( !( Get-VMSwitch | Where {$_.SwitchType -eq "External"} )) -and ( $Type -eq "External" ) ){
		New-VMSwitch -Name "$VMSwitchName" -NetAdapterName $ethernet.Name -AllowManagementOS $true -Notes 'Parent OS, VMs, LAN'
        If($?){return 1}Else{return 0}
	}
    return 0
}

function CreateVHD($VMName, $Master, $VHDPath){
    $VhdExist=Get-ChildItem -Path "$VHDpath" -Filter *.vhdx
    $i=0
    while($i -lt $VhdExist.count){
       if("$VMName" -cmatch $VhdExist[$i].Name){
            return 0
       }
    $i++
    }
    New-VHD -ParentPath "$Master" -Path "$VHDPath\$VMName.vhdx" -Differencing
    If($?){return 1}Else{return 0}
}

function CreateVM($VMName, $VMPath, $VHD){
    $VmsExist = Get-VM
    $i=0
    while($i -lt $VmsExist.count){
        if("$VMName" -cmatch $VmsExist[$i].Name){
            return 0
        }
        $i++
    }
    New-VM -MemoryStartupBytes 1Gb -Name "$VMName" -Generation 2 -VHDPath "$VHD" -Path "$VMpath"
    If($?){return 1}Else{return 0}
}

function AddVMSwitch($VMName, $VMSwitchName, $MACadress){
    $VMSwitch = Get-VMNetworkAdapter -VMName "$VMName"
    $i=0
    while($i -lt $VMSwitch.count){
        if("$VMSwitchName" -eq $VMSwitch[$i].Name){
            return 0
        }
        $i++
    }
    Add-VMNetworkAdapter -VMName $VMName -SwitchName $VMSwitchName -Name $VMSwitchName -StaticMacAddress $MACadress
    If($?){return 1}Else{return 0}
}

function ConvertIPtoMAC($IPAdress){
    $MacAdressOctet = $IpAdress.Split(".")
    If($MacAdressOctet.Count -eq 4){
        $MacAdress = "00-00"
        for ($i=0; $i -lt 4; $i++){
            $MacAdress += "-"
            If(([convert]::ToDecimal($MacAdressOctet[$i])) -lt 16){
                $MacAdress += "0" + ([convert]::ToString($MacAdressOctet[$i],16))
            }Else{
                $MacAdress += ([convert]::ToString($MacAdressOctet[$i],16))
            }
        }
        return "$MacAdress"
    }Else{
        return 0
    }
}

function ConvertMACtoIP($MACAdress){
    $IPAdressOctet = $MACAdress.Split("-")
    If($IPAdressOctet.Count -eq 6){
        for ($i=2; $i -lt 6; $i++){
            $IPAdress += [string]([convert]::ToInt32($IPAdressOctet[$i],16)) + "."
        }
        return "$IPAdress"
    }Else{
        return 0
    }
}