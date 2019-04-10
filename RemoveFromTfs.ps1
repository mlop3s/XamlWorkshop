# Remove unnecessary files  
get-childitem . -include *.vssscc,*.user,*.vspscc,*.pdb,Debug -recurse |   
%{   
    remove-item $_.fullname -force -recurse   
}  

# Remove the bindings from the sln files  
get-childitem . -include *.sln -recurse |   
%{   
    $file = $_;   
    $inVCSection = $False;  
    get-content $file |   
    %{   
        $line = $_.Trim();   
        if ($inVCSection -eq $False -and $line.StartsWith('GlobalSection') -eq $True -and $line.Contains('VersionControl') -eq $True) {   
            $inVCSection = $True   
        }   
        if ($inVCSection -eq $False) {   
            add-content ($file.fullname + '.new') $_   
        }   
        if ($inVCSection -eq $True -and $line -eq 'EndGlobalSection') {   
            $inVCSection = $False  
        }  
    }  
    mv ($file.fullname + '.new') $file.fullname -force   
}  

# Remove the bindings from the csproj files  
get-childitem . -include *.csproj -recurse |   
%{   
    $file = $_;   
    get-content $file |   
    %{   
        $line = $_.Trim();   
        if ($line.StartsWith('<Scc') -eq $False) {  
            add-content ($file.fullname + '.new') $_   
        }  
    }  
    mv ($file.fullname + '.new') $file.fullname -force   

}