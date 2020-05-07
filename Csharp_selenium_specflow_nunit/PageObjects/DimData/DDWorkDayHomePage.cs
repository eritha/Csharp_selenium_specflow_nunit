using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.PageObjects.DimData
{
    class DDWorkDayHomePage : BasePObject
    {
        public string xpathTitleHomePage = "XPATH=.//title[text()='Home - Workday']";
        public DDWorkDayHomePage(IWebDriver driver) : base(driver) { }

        public void WaitUntilHomePageLoad()
        {
            seleLibs.WaitUntilPageContainElement(xpathTitleHomePage);
        }
    }
}