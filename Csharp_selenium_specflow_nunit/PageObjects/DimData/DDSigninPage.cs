using Csharp_selenium_specflow_nunit.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.PageObjects.DimData
{
    class DDSigninPage : BasePObject
    {
        string idLblSiteStatus = "ID=idp_SignInThisSiteStatusLabel";
        string idLblCompanyLogo = "ID=companyLogo";
        string idRadioBtnSigninToThisSite = "ID=idp_ThisRpRadioButton";
        string xpathLblSigninToThisSite = "XPATH=.//input[@id='idp_ThisRpRadioButton']/following-sibling::label";
        string idRadioBtnSigninToOthersSite = "ID=idp_OtherRpRadioButton";
        string xpathLblSigninToOthersSite = "XPATH=.//input[@id='idp_OtherRpRadioButton']/following-sibling::label";
        string idDrpSigninToOthersSite = "ID=idp_RelyingPartyDropDownList";
        string idBtnSignIn = "ID=idp_SignInButton";
        string idInpUserName = "ID=userNameInput";
        string idInpPassword = "ID=passwordInput";
        string idSubmitLogin = "ID=submitButton";
        string xpathLblWelcome = "XPATH=.//h1[@class='workdayHome-j']";

        public DDSigninPage(IWebDriver driver) : base(driver) { }

        public void VerifySignInOptionPage()
        {
            seleLibs.PageShouldContainElement(idLblSiteStatus);
            seleLibs.PageShouldContainElement(idLblCompanyLogo);
            seleLibs.PageShouldContainElement(idRadioBtnSigninToThisSite);
            seleLibs.PageShouldContainElement(xpathLblSigninToThisSite);
            seleLibs.PageShouldContainElement(idRadioBtnSigninToOthersSite);
            seleLibs.PageShouldContainElement(xpathLblSigninToOthersSite);
            seleLibs.PageShouldContainElement(idDrpSigninToOthersSite);
            seleLibs.PageShouldContainElement(idBtnSignIn);
        }

        // ACTIONS
        public void SelectOptions(String p0)
        {
            if (p0.Equals("Sign in to this site."))
                seleLibs.ClickElement(idRadioBtnSigninToThisSite);
            else
                seleLibs.ClickElement(idRadioBtnSigninToOthersSite);
        }

        public void SelectDropdownSites(String p0)
        {
            seleLibs.SelectDropdown(idDrpSigninToOthersSite, p0);
        }

        public void ClickSigninButton()
        {
            seleLibs.ClickElement(idBtnSignIn);
        }

        public void InputCredentialsAndSubmit(String username, String password)
        {
            if (Configs.varBrowser.ToLower().Equals("chrome"))
            {
                seleLibs.InputText(idInpUserName, username);
                seleLibs.InputText(idInpPassword, "Hell0nttVn");
                seleLibs.ClickElement(idSubmitLogin);
            }
            else
                seleLibs.InputauthenticationPopupAndSubmit(username, "Hell0nttVn");
        }

        // VERIRY
        public void SiteStatusShouldBe(String p0)
        {
            seleLibs.ElementTextShouldBe(idLblSiteStatus, p0);
        }

        public void RadioBtnShouldBeChecked(string p0)
        {
            if (p0.Equals("Sign in to this site."))
                seleLibs.RadioButtonShouldBeChecked(idRadioBtnSigninToThisSite);
            else
                seleLibs.RadioButtonShouldBeChecked(idRadioBtnSigninToOthersSite);
        }

        public void RadioBtnShouldNotBeChecked(string p0)
        {
            if (p0.Equals("Sign in to this site."))
                seleLibs.RadioButtonShouldNotBeChecked(idRadioBtnSigninToThisSite);
            else
                seleLibs.RadioButtonShouldNotBeChecked(idRadioBtnSigninToOthersSite);
        }
        internal void DropdownSelectSiteShouldBeDisabled()
        {
            seleLibs.ElementShouldBeDisabled(idDrpSigninToOthersSite);
        }

        internal void DropdownSelectSiteShouldBeEnabled()
        {
            seleLibs.ElementShouldBeEnabled(idDrpSigninToOthersSite);
        }

        internal void DropdownSiteSelectionsTextShouldBe(string p0)
        {
            seleLibs.DropdownValueShouldBe(idDrpSigninToOthersSite, p0);
        }

        internal void PageShouldShowWelcomeText(string p0)
        {
            seleLibs.WaitUntilPageContainElement(xpathLblWelcome);
            seleLibs.ElementTextShouldBe(xpathLblWelcome, p0);
        }
    }
}