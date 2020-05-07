using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_selenium_specflow_nunit.PageObjects.DemoEcommerce
{
    class LoginPage : BasePObject
    {
        public string InputUserName = "XPATH=.//div[@class='mod-login']//input[not(contains(@type,'password'))]";
        public string InputPassword = "XPATH=.//div[@class='mod-login']//input[@type='password']";
        public string ButtonLogin = "XPATH=.//button[@type='submit']";
        public string LabelError = "XPATH=.//div[@class='mod-login']//input[not(contains(@type,'password'))]/following-sibling::span";

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(string name, string pass)
        {
            seleLibs.InputText(InputUserName, name);
            seleLibs.InputText(InputPassword, pass);
            seleLibs.ClickElement(ButtonLogin);
        }
    }
}
