param (
	[parameter(Mandatory=$true)]
	[String] $TestDllPath,

	[parameter(Mandatory=$true)]
	[int] $NumberOfTimes,

	[parameter(Mandatory=$false)]
	[int] $SendEmail = $false
)

# $TestDllPath = "C:\Users\rkkr9\Desktop\MSCS_SQ19\Testing n Debugging\projects\OpenE6B\OpenE6B\OpenE6BTests\bin\Debug\OpenE6BTests.dll";

$failure = $false;
$emailAddress = "rokkamkarthi@seattleu.edu"
$subject = "Automated Message: All Unit Tests passed!";
$vsTestExe = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe";

Write-Host;
Write-Host;
Write-Host;

Write-Host "Tests started at $(Get-Date)" -ForegroundColor Green;
Write-Host;
for($i = 0; $i -lt $NumberOfTimes; $i++) {
	Write-Host;
	Write-Host "Starting iteration: " $($i + 1) -foregroundColor Magenta; 
	$a = & $vsTestExe $TestDllPath;
	Write-Host;

	if ($a.Contains("Test Run Successful.") -ne $true) {
		Write-Host "Failure Detected!!!" -foregroundColor Red; 
		$failure = $true;
	} else {
		Write-Host "Run sucessful!!!" -foregroundColor Green;
		Write-Host;
	}
}
Write-Host;
Write-Host "Tests ended at $(Get-Date)" -ForegroundColor Green;

if($SendEmail) {
	Write-Host;
	Write-Host "Sending results of tests to email";
	Write-Host;
	if ($failure) {
		Write-Host "We have detected a failure! Sending failure msg!" -foregroundColor Red; 
		$subject = "Automated Message: Failure Running Unit Tests!";
	}
	$cred = get-credential
	$body = "This is an automated generated e-mail message. Take a look at the results of the unit tests run!"
	Send-MailMessage -To $emailAddress -from $emailAddress -Subject $subject -Body $body -BodyAsHtml -smtpserver smtp.office365.com -usessl -Credential $cred -Port 587;
	Write-Host "Email sent";
}