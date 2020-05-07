# Automation Page Object Model Framework - Using C#.NET, SpecFlow, Selenium, Nunit, Extent Report
## Overview [structure] (https://erit-ha.tinytake.com/tt/MzY2OTU1OF8xMTEzNjY0NA)

```
This project is to provide a good starting structure point for those looking to use SpecFlow, Selenium and some other extensions. 
It is also intended to demonstrate how to implement design patterns in a test framework (Page Object Model), Where many test frameworks 
will give some solution demonstrates like scalable, maintainable, readable and repeatable.
```

**Resources**
- [Selenium](https://www.guru99.com/page-object-model-pom-page-factory-in-selenium-ultimate-guide.html)
- [Selenium](http://www.seleniumhq.org/)
- [SpecFlow](http://specflow.org/)
- [Nunit](https://nunit.org/)
- [Extent Report](https://extentreports.com/)
- [FluentAssertions](https://fluentassertions.com/)

## Examples Demo with:

- Goes to Dimension Data Authentication page "https://auth.dimensiondata.com/adfs/ls/idpinitiatedSignon.aspx"
- Verify all element in selection page
- Select checkbox to sign in the other sites
- Select dropdown with option "GIS - Workday"
- Click button Sign in
- Enter valid credentials data
- Submit login button
- Verify login Workday successfully

## Pre-requisites
* Visual Studio: 2017
* SpecFlow <3.0.225>
* SpecFlow.NUnit <3.0.225>
* SpecFlow.Tools.MsBuild.Generation <3.0.225>
* NUnit <3.12.0>
* NUnit.Console <3.10.0>
* NUnit.ConsoleRunner <3.10.0>
* NUnit.Runners <3.10.0>
* Selenium.Support <3.141.0>
* Selenium.WebDriver <3.141.0>
* Selenium.WebDriver.ChromeDriver <75.0.3770.140>
* Selenium.WebDriver.GeckoDriver <0.24.0>
* Selenium.WebDriver.IEDriver <3.141.59>
* ExtentReports <3.1.3> 
* FluentAssertions <5.7.0>

### Visual Studio

Visual Studio needs a little extra configuration. Install these extensions:
- SpecFlow for Visual studio:
	+ Extension for VS 2015: https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2015
	+ Extension for VS 2017: https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017
- Or install throught IDE:
	+ select “Tools”, “Extensions and Updates…” from the menu. Click on "Online" on the left, and search for "SpecFlow for Visual studio", then click "Download"

## Running Tests
You can run them in the Unit Test explorer on Visual Studio or via command line

Build
```
$ msbuild ... 
```

### IDE - Visual Studio

When you build the test project, the tests appear in Test Explorer. 
If Test Explorer is not visible, choose Test on the Visual Studio menu, choose Windows, and then choose Test Explorer.
+ Right-click menu for a selected test and then choose Run Selected Tests.

### Command Line

Run the test from file "RunProject.bat"

Run all tests at .sln directory
```
$ ".\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe" "AutomationPOM\bin\Debug\AutomationPOM.dll" --result="TestResult.xml;format=nunit3"
```

Run tests by Cat
```
$ ".\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe" "AutomationPOM\bin\Debug\AutomationPOM.dll" --result="TestResult.xml;format=nunit3" --where "cat == Dimension"
```

Run tests with parameters
```
$ ".\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe" "AutomationPOM\bin\Debug\AutomationPOM.dll" --result="TestResult.xml;format=nunit3" --where "cat == Dimension" --testparam=browser=Chrome
```