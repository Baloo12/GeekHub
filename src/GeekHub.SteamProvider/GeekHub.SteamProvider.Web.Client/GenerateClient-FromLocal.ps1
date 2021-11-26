[CmdletBinding()]
param()
 
if (!$PSBoundParameters.ContainsKey('ErrorAction')) { $ErrorActionPreference = 'Stop' }
 
$commonParams = @{
    ErrorAction = $ErrorActionPreference;
    Verbose = $VerbosePreference -ne 'SilentlyContinue'
}
 
. "$PSScriptRoot\GenerateClient-Functions.ps1"
 
$endpoint = "http://localhost:5000/swagger/v1/swagger.json"
$applicationPath = "$PSScriptRoot\..\GeekHub.SteamProvider.Web"
$clientPath = "$PSScriptRoot\..\GeekHub.SteamProvider.Web.Client\GeekHub.SteamProvider.Web.Client.csproj"
 
$application = Start-WebApp -Endpoint $endpoint -ApplicationPath $applicationPath
 
Generate-Client -Endpoint $endpoint -ClientPath $clientPath @commonParams 
 
Stop-WebApp -Application $application