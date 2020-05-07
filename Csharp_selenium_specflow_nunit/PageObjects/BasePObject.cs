using Csharp_selenium_specflow_nunit.Utility;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace Csharp_selenium_specflow_nunit.PageObjects
{
    public abstract class BasePObject
    {
        // Get selenium base URL from app config(default) or run command line with Nunit parameters
        protected string SeleniumBaseUrl = Configs.varSeleniumBaseUrl;

        public Helper seleLibs;
        private readonly IWebDriver _driver;

        public BasePObject(IWebDriver driver)
        {
            _driver = driver;
            seleLibs = new Helper(_driver);
        }

        /// <summary>
        /// Action: Navigate to Home page from any pages
        /// </summary>
        public void NavigateHomePage()
        {
            _driver.Navigate().GoToUrl(SeleniumBaseUrl);
        }

        /// <summary>
        /// Action: Navigate from any pages to the page <url>
        /// </summary>
        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Verify: The current page title <title>
        /// </summary>
        public void AssertTitle(string title)
        {
            string pageTitle = _driver.Title;
            pageTitle.Should().Be(title);
        }

        /// <summary>
        /// Verify: The current page contains title <title>
        /// </summary>
        public void AssertContainsTitle(string title)
        {
            string pageTitle = _driver.Title;
            pageTitle.Should().Contain(title);
        }

        //public void InputauthenticationPopupAndSubmit(String userName, String password)
        //{
        //    public AutoItX3 AutoIT = new AutoItX3();

        //    //Set Selenium page load timeout to 2 seconds so it doesn't wait forever
        //    Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(2));

        //    //Ingore the error
        //    try
        //    {
        //        Driver.Url = url;
        //    }
        //    catch
        //    {
        //        return;
        //    } 
        //    //Wait for the authentication window to appear, then send username and password
        //    AutoItX.WinWait("Authentication Required");
        //    AutoIT.WinActivate("Authentication Required");
        //    AutoIT.Send("username");
        //    AutoIT.Send("{TAB}");
        //    AutoIt.Send("password");
        //    AutoIT.Send("{ENTER}");

        //    //Return Selenium page timeout to infinity again
        //    Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(-1));
        //}
    }
}