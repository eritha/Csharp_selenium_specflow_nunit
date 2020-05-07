using Csharp_selenium_specflow_nunit.Base;
using Csharp_selenium_specflow_nunit.PageObjects;
using Csharp_selenium_specflow_nunit.Utility;
using OpenQA.Selenium;
using System;

namespace Csharp_selenium_specflow_nunit.PageObjects.AIA
{
    public class SignInFinessePage : BasePObject
    {
        // Define locators
        string ID_LBL_APP_NAME = "ID=app-name"; 
        string ID_TXT_USERNAME = "ID=username";
        string ID_BTN_SUBMIT_NEXT = "ID=signin-button";
        string ID_TXT_PASSWORD = "ID=password";
        string ID_TXT_EXTENSION_NUM = "ID=extension";
        string ID_BTN_SUBMIT_SIGNIN = "ID=signin-button";

        // Certificate page
        string XPATH_BTN_ADVANCED = "XPATH=.//button[contains(text(),'Advanced')]";
        string ID_LNK_PROCEED_CHROME = "ID=proceed-link";
        string ID_BTN_ACCEPT_CONTINUE_FIREFOX = "ID=exceptionDialogButton";

        public SignInFinessePage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Verify sign in page all elements
        /// </summary>
        public void VerifySignInlandingPage()
        {
            ProceedToPassCertificate();
            seleLibs.PageShouldContainElement(ID_LBL_APP_NAME);
            seleLibs.PageShouldContainElement(ID_TXT_USERNAME);
            seleLibs.PageShouldContainElement(ID_BTN_SUBMIT_NEXT);
        }

        /// <summary>
        /// Click btn Advanced, then click link proceed on chrome or button accept the risk and continue on firefox
        /// </summary>
        public void ProceedToPassCertificate()
        {
            seleLibs.ClickElement(XPATH_BTN_ADVANCED);
            if (Configs.varBrowser.Equals("Chrome"))
                seleLibs.ClickElement(ID_LNK_PROCEED_CHROME);
            else if (Configs.varBrowser.Equals("Firefox"))
                seleLibs.ClickElement(ID_BTN_ACCEPT_CONTINUE_FIREFOX);
        }

        /// <summary>
        /// Verify sign in page all elements
        /// </summary>
        public void VerifySignInIdentityCheckPage()
        {
            seleLibs.PageShouldContainElement(ID_LBL_APP_NAME);
            seleLibs.PageShouldContainElement(ID_TXT_USERNAME);
            seleLibs.PageShouldContainElement(ID_TXT_PASSWORD);
            seleLibs.PageShouldContainElement(ID_TXT_EXTENSION_NUM);
            seleLibs.PageShouldContainElement(ID_BTN_SUBMIT_SIGNIN);
        }

        /// <summary>
        /// Action: Input Username
        /// </summary>
        public void InputUsername(String username)
        {
            seleLibs.InputText(ID_TXT_USERNAME, username);
        }

        /// <summary>
        /// Action: Input Password
        /// </summary>
        public void InputPassword(String password)
        {
            seleLibs.InputText(ID_TXT_PASSWORD, password);
        }

        /// <summary>
        /// Action: Input Extension
        /// </summary>
        public void InputExtension(String extension)
        {
            seleLibs.InputText(ID_TXT_EXTENSION_NUM, extension);
        }

        /// <summary>
        /// Action: Click button Next
        /// </summary>
        public void ClickButtonNext()
        {
            seleLibs.ClickElement(ID_BTN_SUBMIT_NEXT);
        }

        /// <summary>
        /// Action: Click button Sign In
        /// </summary>
        public void ClickButtonSignIn()
        {
            seleLibs.ClickElement(ID_BTN_SUBMIT_SIGNIN);
        }

        /// <summary>
        /// Action: Input username & Submit at Landing page
        /// </summary>
        public void InputUsernameAndSubmitAtLandingPage(String username)
        {
            InputUsername(username);
            ClickButtonNext();
        }

        /// <summary>
        /// Action: Input credentials & Submit at Identity Check Page
        /// </summary>
        public void InputCredentialsAndSubmitAtIdentityCheckPage(String password, String extension)
        {
            InputPassword(password);
            InputExtension(extension);
            ClickButtonSignIn();
        } 
        
    }
}