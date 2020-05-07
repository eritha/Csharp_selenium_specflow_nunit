using Csharp_selenium_specflow_nunit.PageObjects.AIA;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps
{
    [Binding]
    public class FinesseCustomerJourneyTabSteps
    {
        private readonly FinesseDesktopCustomerJourneyTab _finessCustomerJourneyTab;

        public FinesseCustomerJourneyTabSteps(IWebDriver driver)
        {
            _finessCustomerJourneyTab = new FinesseDesktopCustomerJourneyTab(driver);
        }

        [Then(@"The Customer Journey tab should be displayed successfully")]
        public void ThenTheCustomerJourneyTabShouldBeDisplayedSuccessfully()
        {
            _finessCustomerJourneyTab.VerifyFinesseDesktopCustomerJourneyTab();
        }
    }
}