using Csharp_selenium_specflow_nunit.PageObjects.DemoEcommerce;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit
{
    [Binding]
    public class VerifyLazadaLoginPageSteps
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        public VerifyLazadaLoginPageSteps(IWebDriver driver)
        {
            _homePage = new HomePage(driver);
            _loginPage = new LoginPage(driver);
        }

        [Given(@"I navigated to Lazada Home Page")]
        public void GivenINavigatedToLazadaHomePage()
        {
            _homePage.NavigateHomePage();
        }

        [Given(@"I click the link Login")]
        public void GivenIClickTheLinkLogin()
        {
            _homePage.ClickLinkLogin();
        }

        [Then(@"The login page title should be ""(.*)""")]
        public void ThenTheLoginPageTitleShouldBe(string p0)
        {
            _loginPage.AssertContainsTitle(p0);
        }
    }
}

