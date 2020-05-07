set currentTimestamp=Build%date:~10,4%-%date:~4,2%-%date:~7,2%_Time%time:~0,2%.%time:~3,2%.%time:~6,2%
IF not exist ".\HTMLReport\%currentTimestamp%" (mkdir ".\HTMLReport\%currentTimestamp%") 
:: cd %currentTimestamp% 

::del ".\HTMLReport\*.html"
:: ========= SPECFLOW NUNIT COMMAND =========
::".\packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" nunitexecutionreport --ProjectFile BookShop.AcceptanceTests.csproj --xmlTestResult CustomNunitTestResult.xml --testOutput CustomNunitTestOutput.txt --OutputFile CustomSpecflowTestReport.html
:: ========= NUNIT COMMAND =========
".\packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" "Csharp_selenium_specflow_nunit\bin\Debug\Csharp_selenium_specflow_nunit.dll" --result="TestResult.xml;format=nunit3" --work=".\HTMLReport\%currentTimestamp%" --where "cat == ALL"
:: ========= GENERAL HTML REPORT =========
".\packages\ReportUnit.1.2.1\tools\ReportUnit.exe" ".\HTMLReport\%currentTimestamp%" ".\HTMLReport\%currentTimestamp%"
:: ========= OPEN HTML FILE ========= 
::".\HTMLReport\%currentTimestamp%\Index.html"
::pause

::"%cd%/../../packages\NUnit.ConsoleRunner.3.9.0\tools\nunit3-console.exe" --out="TestResult.txt" --result="TestResult.xml" Debug\AIAAutoProject.dll --where "cat != Dimension"
::"%cd%/../../packages\ReportUnit.1.2.1\tools\reportunit.exe" Debug\cSpecFlowNew01Nunit3.csproj --xmlTestResult TestResult.xml --testOutput TestResult.txt --OutputFile "%currentTimestamp% .html
::"%cd%/../../packages\ReportUnit.1.2.1\tools\reportunit.exe" "%cd%/../cSpecFlowNew01Nunit3" --xmlTestResult TestResult.xml --testOutput TestResult.txt --OutputFile 2019-07-22-sanityCheck.html