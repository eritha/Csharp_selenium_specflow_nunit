using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.PageObjects.DimData
{
    class DemoPage : BasePObject
    {
        public DemoPage(IWebDriver driver) : base(driver) { }

        public void SearchFor(string searchText)
        {
            seleLibs.ClearElementText(SearchBox);
            seleLibs.InputText(SearchBox, searchText);
            seleLibs.PressEnter(SearchBox);
        }

        public void SelectResult(string expResult)
        {
            seleLibs.FindElements("XPATH=.//a/h3[contains(text(),'" + expResult + "')]")[0].Click();
        }


        //public String SearchBox = "CSS=[name='q']";
        public String SearchBox = "XPATH=.//input[@name='q']";

        public String SearchResults = "CSS=#ires .g .r a";
    }
}
