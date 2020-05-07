using Csharp_selenium_specflow_nunit.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;

namespace Csharp_selenium_specflow_nunit.Base
{
    public class DriverFactory
    {
        // Get browser from app config(default) or run command line with Nunit parameters
        //public static string browser = TestContext.Parameters["STG_BROWSER"] != null ? TestContext.Parameters["STG_BROWSER"] : ConfigurationManager.AppSettings["STG_BROWSER"];
        //public static string browser = Configs.varBrowser;

        /// <summary>
        /// Create Selenium Webdriver
        /// </summary> 
        /// <returns>Return IWebDriver</returns>
        public IWebDriver CreateDriver()
        {
            switch (Configs.varBrowser.ToUpperInvariant())
            {
                case "CHROME":
                    return new ChromeDriver();
                case "FIREFOX":
                    return new FirefoxDriver();
                case "IE":
                    return new InternetExplorerDriver();
                default:
                    throw new ArgumentException($"Browser not yet implemented: {Configs.varBrowser}");
            }
        }
    }
}
