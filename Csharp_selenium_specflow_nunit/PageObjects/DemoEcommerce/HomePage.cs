using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.PageObjects.DemoEcommerce
{
    class HomePage : BasePObject
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void ClickLinkLogin()
        {
            seleLibs.ClickElement(lnkLogin);
        }

        public String lnkLogin = "XPATH=.//div[@id='anonLogin']/a";
    }
}
