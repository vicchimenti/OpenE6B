param (
	[parameter(Mandatory=$true)]
	[String] $slnPath
)

#$slnPath = "C:\Users\rkkr9\Desktop\MSCS_SQ19\Testing n Debugging\projects\OpenE6B\OpenE6B\OpenE6B.sln";
$msBuildExe = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe";

Write-Host;
Write-Host;

Write-Host "Cleaning $($slnPath)" -ForegroundColor Green;
Write-Host;
& "$($msBuildExe)" "$($slnPath)" /t:Clean /m

Write-Host;
Write-Host;

Write-Host "Building $($slnPath)" -foregroundcolor Green;
Write-Host;
& "$($msBuildExe)" "$($slnPath)" /t:Build /m