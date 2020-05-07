using Csharp_selenium_specflow_nunit.PageObjects.AIA;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps
{
    [Binding]
    public class LoginFinesseSteps
    {
        private readonly SignInFinessePage _signin;
        private readonly FinesseDesktopHomePage _home;

        public LoginFinesseSteps(IWebDriver driver)
        {
            _signin = new SignInFinessePage(driver);
            _home = new FinesseDesktopHomePage(driver);
        } 

        [When(@"The Sign In Landing page is displayed")]
        public void WhenTheSignInLandingPageIsDisplayed()
        {
            _signin.VerifySignInlandingPage();
        }

        [When(@"I enter the valid user name is ""(.*)""")]
        public void WhenIEnterTheValidUserNameIs(string p0)
        {
            _signin.InputUsername(p0);
        }

        [When(@"Clicking the button Next")]
        public void WhenClickingTheButtonNext()
        {
            _signin.ClickButtonNext();
        }

        [Then(@"I enter the valid password is ""(.*)"" and extension ""(.*)""")]
        public void ThenIEnterTheValidPasswordIsAndExtension(string p0, string p1)
        {
            _signin.InputPassword(p0);
            _signin.InputExtension(p1);
        }

        [Then(@"Clicking the button Sign In")]
        public void ThenClickingTheButtonSignIn()
        {
            _signin.ClickButtonSignIn();
        }

        [Then(@"The finesse desktop should be displayed successfully")]
        public void ThenTheFinesseDesktopShouldBeDisplayedSuccessfully()
        {
            _home.VerifyFinesseDesktopHomePage();
        }
    }
}
