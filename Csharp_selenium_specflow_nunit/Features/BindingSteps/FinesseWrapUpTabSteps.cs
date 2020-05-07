using Csharp_selenium_specflow_nunit.PageObjects.AIA;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps
{
    [Binding]
    public class FinesseWrapUpTabSteps
    {
        private readonly FinesseDesktopWrapUpTab _finessWrapUpTab;

        public FinesseWrapUpTabSteps(IWebDriver driver)
        {
            _finessWrapUpTab = new FinesseDesktopWrapUpTab(driver);
        } 

        [Then(@"The Wrap Up tab should be displayed successfully")]
        public void ThenTheWrapUpTabShouldBeDisplayedSuccessfully()
        {
            _finessWrapUpTab.VerifyFinesseDesktopCallInfoTab();
        }
    }
}
