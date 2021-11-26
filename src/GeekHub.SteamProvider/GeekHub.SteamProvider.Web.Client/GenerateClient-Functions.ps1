function IsVsWhereExists {
    [CmdletBinding()]
    param()
 
    return Get-Command "vswhere.exe" -ErrorAction SilentlyContinue
}
 
function DownloadVsWhere {
    [CmdletBinding()]
    param()
 
    Write-Host "downloading vswhere.exe"
    $vswhere_url = "https://github.com/microsoft/vswhere/releases/download/2.8.4/vswhere.exe"
    $vswherePath = "$PSScriptRoot\vswhere.exe"
    $wc = New-Object System.Net.WebClient
    $wc.DownloadFile($vswhere_url, $vswherePath)
    Write-Host "vswhere.exe download complete`n"
}
 
function Request-WebApp {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$Endpoint
    )
 
    if (!$PSBoundParameters.ContainsKey('ErrorAction')) { $ErrorActionPreference = 'Stop' }
 
    $commonParams = @{
        ErrorAction = $ErrorActionPreference;
        Verbose = $VerbosePreference -ne 'SilentlyContinue'
    }
 
    $startTime = Get-Date
    $statusCode = 404
    do {
        try {
            $response = Invoke-WebRequest $Endpoint `
                -TimeoutSec 5 `
                -UseBasicParsing `
                @commonParams 
            $statusCode = $response.StatusCode
        }
        catch {
            Write-Host "Error: Unable to connect to the server" -ForegroundColor Red
        }
    } while ($statusCode -notmatch 200 -and $startTime.AddSeconds(30) -gt (Get-Date))
     
    if ($statusCode -ne 200) {
        Write-Host "Error: The application is not responsive." -ForegroundColor Red
        Exit
    }
 
    Write-Host "Response from server received. Status code is $statusCode."
}
 
function Generate-Client {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$Endpoint,
        [Parameter(Mandatory=$true)]
        [string]$ClientPath
    )
 
    Write-Host "Generating Clients from: $Endpoint`n"
 
    # Check the endpoint is up
    Write-Host "Checking wep application is up..."
    Request-WebApp -Endpoint $Endpoint
 
    # Download vswhere
    Write-Output "Checking vswhere..."
    $vswherePath = if (IsVsWhereExists)
    {
        "vswhere.exe"
    } else {
        DownloadVsWhere
        "$PSScriptRoot\vswhere.exe"
    }
 
    # Import VS Development tools
    Write-Output "Locating MSBuild"
    $installationPath = & $vswherePath -prerelease -latest -property installationPath
    if (!$installationPath -or !(test-path $installationPath)) {
        throw "`nCould not find MSbuild... `nExiting script"
    }
    $msBuildPath = "$installationPath\MSBuild\Current\Bin\msbuild.exe"
 
    Write-Output "Generating..."
    & $msBuildPath $ClientPath /t:Generate /p:ServiceUrl=$Endpoint
    Write-Host "`nClients Generated" -ForegroundColor Green
}
 
function Start-WebApp {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [string]$Endpoint,
        [Parameter(Mandatory=$true)]
        [string]$ApplicationPath
    )
 
    if (!$PSBoundParameters.ContainsKey('ErrorAction')) { $ErrorActionPreference = 'Stop' }
 
    $commonParams = @{
        ErrorAction = $ErrorActionPreference;
        Verbose = $VerbosePreference -ne 'SilentlyContinue'
    }
 
    $launchProfile = 'Local'
 
    # Run application
    Write-Host "Running application... $ApplicationPath"
    $application = Start-Process `
        -FilePath 'dotnet' `
        -WorkingDirectory $ApplicationPath `
        -ArgumentList "run --launch-profile $launchProfile" `
        -PassThru `
        @commonParams 
 
    return $application
}
 
function Stop-WebApp {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [object]$Application
    )
 
    if (!$PSBoundParameters.ContainsKey('ErrorAction')) { $ErrorActionPreference = 'Stop' }
 
    $commonParams = @{
        ErrorAction = $ErrorActionPreference;
        Verbose = $VerbosePreference -ne 'SilentlyContinue'
    }
 
    #Stop application
    Stop-Process $Application @commonParams 
    Write-Host "Application stopped."
}