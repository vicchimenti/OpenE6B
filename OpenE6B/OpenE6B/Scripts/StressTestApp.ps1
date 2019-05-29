﻿param (
	#[parameter(Mandatory=$true)]
	#[String] $TestDllPath,

	[parameter(Mandatory=$true)]
	[int] $NumBackGroundProcesses,

	[parameter(Mandatory=$true)]
	[int] $NumberOfTimes
)

#$slnPath = "C:\Users\rkkr9\Desktop\MSCS_SQ19\Testing n Debugging\projects\OpenE6B\OpenE6B\OpenE6B.sln";

$TestDllPath = "C:\Users\rkkr9\Desktop\MSCS_SQ19\Testing n Debugging\projects\OpenE6B\OpenE6B\OpenE6BTests\bin\Debug\OpenE6BTests.dll";
$runTestSuite = ".\RunTestSuite.ps1"

Write-Host "Stress Tests started at $(Get-Date)" -ForegroundColor Green;
Write-Host;
& "$($runTestSuite)" "$($TestDllPath)" "$($NumberOfTimes)"
Write-Host;
Write-Host "Stress Tests ended at $(Get-Date)" -ForegroundColor Green;