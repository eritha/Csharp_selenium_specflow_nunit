using Csharp_selenium_specflow_nunit.PageObjects.DemoEcommerce;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps.DemoEcommerce.Lazada
{
    [Binding]
    public class VerifyLazadaHomePageSteps
    {
        private readonly HomePage _page;

        public VerifyLazadaHomePageSteps(IWebDriver driver)
        {
            _page = new HomePage(driver);
        }

        [Given(@"I navigated to ""(.*)""")]
        public void GivenINavigatedTo(string url)
        {
            _page.Navigate(url);
        }

        [Then(@"the workday home page should be shown with title ""(.*)""")]
        [Then(@"browser title is ""(.*)""")]
        public void ThenBrowserTitleIs(string p0)
        {
            _page.AssertTitle(p0);
        }
    }
}
