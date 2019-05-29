<#
 .SYNOPSIS
	Run Unit Tests from the command line a number of specified times.
 .DESCRIPTION
	Run C# Unit Tests from the command line in a loop
 .PARAMETER NumberOfTimes
	The number of times you want to run the unit tests in a loop
 .EXAMPLE
	RunUnitTests -NumberOfTimes 5
#>

param(
		[Parameter(Mandatory=$true)][int]$NumberOfTimes
)

$failure = $false;
$subject = "Automated Message: All Unit Tests passed!";
$TestDir = "C:\Users\encin\source\repos\OpenE6B\OpenE6B\OpenE6BTests\bin\Debug";
$TestBinary = "OpenE6BTest.dll";

cd $TestDir;
# dir
# write-host $TestDir;
write-host
write-host

# & 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe' .\OpenE6BTests.dll

for($i=0;$i -lt $NumberOfTimes;$i++){ write-host; write-host "Starting iteration: " $($i + 1) -foregroundColor Magenta; $a = & 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe' .\OpenE6BTests.dll; write-host; if ($a.Contains("Test Run Successful.") -ne $true) { write-host "Failure Detected!!!" -foregroundColor Red; $failure = $true; } else { write-host "Run sucessful!!!" -foregroundColor Green; write-host } }

if ($failure) { write-host "We have detected a failure! Sending failure msg!" -foregroundColor Red; $subject = "Automated Message: Failure Running Unit Tests!"; }

$cred = get-credential
$body = "This is an automated generated e-mail message. Take a look at the results of the unit tests run!"
Send-MailMessage -To encinamauric@seattleu.edu -from encinamauric@seattleu.edu -Subject $subject -Body $body -BodyAsHtml -smtpserver smtp.office365.com -usessl -Credential $cred -Port 587;

	
