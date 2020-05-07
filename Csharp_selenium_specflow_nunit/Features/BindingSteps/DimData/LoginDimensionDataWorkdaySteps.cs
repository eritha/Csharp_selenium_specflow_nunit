using Csharp_selenium_specflow_nunit.PageObjects.DimData;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Csharp_selenium_specflow_nunit.Features.BindingSteps.DimData
{
    [Binding]
    public class LoginDimensionDataWorkdaySteps
    {
        private readonly DDSigninPage _page;
        private readonly DDWorkDayHomePage _home;

        public LoginDimensionDataWorkdaySteps(IWebDriver driver)
        {
            _page = new DDSigninPage(driver);
            _home = new DDWorkDayHomePage(driver);
        }

        [Then(@"The sign in option page should be dispayed")]
        public void ThenTheSignInOptionPageShouldBeDispayed()
        {
            _page.VerifySignInOptionPage();
        }

        [Then(@"the site status is ""(.*)""")]
        public void ThenTheSiteStatusIs(string p0)
        {
            _page.SiteStatusShouldBe(p0);
        }

        [Then(@"the radio checkbox ""(.*)"" should be checked as default")]
        public void ThenTheRadioCheckboxShouldBeCheckedAsDefault(string p0)
        {
            _page.RadioBtnShouldBeChecked(p0);
        }

        [Then(@"the radio checkbox ""(.*)"" should not be checked")]
        public void ThenTheRadioCheckboxShouldNotBeChecked(string p0)
        {
            _page.RadioBtnShouldNotBeChecked(p0);
        }

        [Then(@"the dropdown Site selections should be hidden & disabled")]
        public void ThenTheDropdownSiteSelectionsShouldBeHiddenDisabled()
        {
            _page.DropdownSelectSiteShouldBeDisabled();
        }

        [When(@"user click radio checkbox ""(.*)""")]
        public void WhenUserClickRadioCheckbox(string p0)
        {
            _page.SelectOptions(p0);
        }

        [Then(@"dropdown Site selections should be enabled")]
        public void ThenDropdownSiteSelectionsShouldBeEnabled()
        {
            _page.DropdownSelectSiteShouldBeEnabled();
        }

        [When(@"select dropdown Site selections ""(.*)""")]
        public void WhenSelectDropdownSiteSelections(string p0)
        {
            _page.SelectDropdownSites(p0);
        }

        [Then(@"dropdown Site selections text should be ""(.*)""")]
        public void ThenDropdownSiteSelectionsTextShouldBe(string p0)
        {
            _page.DropdownSiteSelectionsTextShouldBe(p0);
        }

        [When(@"click button Sign in")]
        public void WhenClickButtonSignIn()
        {
            _page.ClickSigninButton();
        }

        [When(@"I enter valid account with user name is ""(.*)"" and password is ""(.*)"" then submit")]
        public void WhenIEnterValidAccountWithUserNameIsAndPasswordIs(string p0, string p1)
        {
            _page.InputCredentialsAndSubmit(p0, p1);
        }

        [Then(@"I should see the text ""(.*)""")]
        public void ThenIShouldSeeTheText(string p0)
        {
            _page.PageShouldShowWelcomeText(p0);
        }
    }
}