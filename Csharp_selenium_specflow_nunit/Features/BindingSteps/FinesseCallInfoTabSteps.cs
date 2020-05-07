using Csharp_selenium_specflow_nunit.PageObjects.AIA;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps
{
    [Binding]
    public class FinesseCallInfoTabSteps
    {
        private readonly FinesseDesktopCallInfoTab _finessCallInfoTab;

        public FinesseCallInfoTabSteps(IWebDriver driver)
        {
            _finessCallInfoTab = new FinesseDesktopCallInfoTab(driver);
        }
        [Then(@"The Call Info tab should be displayed successfully")]
        public void ThenTheCallInfoTabShouldBeDisplayedSuccessfully()
        {
            _finessCallInfoTab.VerifyFinesseDesktopCallInfoTab();
        }
    }
}
