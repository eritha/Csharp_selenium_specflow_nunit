using Csharp_selenium_specflow_nunit.PageObjects;
using Csharp_selenium_specflow_nunit.Utility;
using OpenQA.Selenium;

namespace Csharp_selenium_specflow_nunit.PageObjects.AIA
{
    public class FinesseDesktopCallInfoTab : BasePObject
    {
        // Button
        string XPATH_BTN_INTERACTION = "XPATH=.//button[text()='start interaction']";
        string XPATH_BTN_END_CALL = "XPATH=.//button[text()='end call']";
        string XPATH_BTN_READY = "XPATH=.//button[text()='ready']";

        // Define locators - TABLE Call Info
        string XPATH_TABLE_CALL_INFO = "XPATH=.//div[@class='jsgrid']";
        string XPATH_TABLE_CONTENT = "XPATH=.//div[@class='jsgrid-grid-body']";

        public FinesseDesktopCallInfoTab(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Verify Finesse Desktop HomePage tab Call Info displayed
        /// </summary>
        public void VerifyFinesseDesktopCallInfoTab()
        {
            // >>> Handle sikuli to make a call flow Cisco IP Phone
            //SikuliCiscoIpPhone.SelectCiscoIpPhoneTaskBar();
            //AutoItXCiscoIpCommunicator.ForceVitualCiscoIpPhone();
            //AutoItXCiscoIpCommunicator.InputKeypads("0123456789*#");
            seleLibs.PageShouldContainElement(XPATH_TABLE_CALL_INFO);
            seleLibs.PageShouldContainElement(XPATH_TABLE_CONTENT);
        } 
    }
}