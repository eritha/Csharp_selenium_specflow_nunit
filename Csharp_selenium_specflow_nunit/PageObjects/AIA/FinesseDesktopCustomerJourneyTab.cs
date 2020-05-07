using Csharp_selenium_specflow_nunit.PageObjects;
using OpenQA.Selenium;

namespace Csharp_selenium_specflow_nunit.PageObjects.AIA
{
    public class FinesseDesktopCustomerJourneyTab : BasePObject
    {
        // Button Main
        string XPATH_BTN_INTERACTION = "XPATH=.//button[text()='start interaction']";
        string XPATH_BTN_END_CALL = "XPATH=.//button[text()='end call']";
        string XPATH_BTN_READY = "XPATH=.//button[text()='ready']";

        // Customer Journey content
        string XPATH_BTN_REFRESH = "XPATH=.//button[text()='Refresh']";
        string XPATH_TABLE_JOURNEY = "XPATH=.//table[@class='table table-striped']";
        string XPATH_TABLE_HEADER_DATE = "XPATH=.//table[@class='table table-striped']//th[text()='Date']";
        string XPATH_TABLE_HEADER_TIME = "XPATH=.//table[@class='table table-striped']//th[text()='Time']";
        string XPATH_TABLE_HEADER_CALLER_ID = "XPATH=.//table[@class='table table-striped']//th[text()='Caller ID']";
        string XPATH_TABLE_HEADER_AGENT_ID = "XPATH=.//table[@class='table table-striped']//th[text()='Agent ID']";
        string XPATH_TABLE_HEADER_CALL_DISPOSTITION = "XPATH=.//table[@class='table table-striped']//th[text()='Call Disposition']";
        string XPATH_TABLE_HEADER_MAIN = "XPATH=.//table[@class='table table-striped']//th[text()='Main']";
        string XPATH_TABLE_HEADER_SUB1 = "XPATH=.//table[@class='table table-striped']//th[text()='Sub 1']";
        string XPATH_TABLE_HEADER_SUB2 = "XPATH=.//table[@class='table table-striped']//th[text()='Sub 2']";

        string XPATH_TABLE_HEADER_POLICY_NO = "XPATH=.//table[@class='table table-striped']//th[text()='Policy No']";
        string XPATH_TABLE_HEADER_NRIC = "XPATH=.//table[@class='table table-striped']//th[text()='NRIC']";
        string XPATH_TABLE_HEADER_CALL_FROM = "XPATH=.//table[@class='table table-striped']//th[text()='Called From']";
        string XPATH_TABLE_HEADER_FREE_TEXT_MSG = "XPATH=.//table[@class='table table-striped']//th[text()='Free Text']";

        string XPATH_TABLE_JOURNEY_BODY = "XPATH=.//table[@class='table table-striped']/tbody";

        // Button content
        string XPATH_BTN_1 = "XPATH=.//button[text()='btn1']";
        string XPATH_BTN_2 = "XPATH=.//button[text()='btn2']";
        string XPATH_BTN_3 = "XPATH=.//button[text()='btn3']";
        string XPATH_BTN_4 = "XPATH=.//button[text()='btn4']";

        public FinesseDesktopCustomerJourneyTab(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Verify Finesse Desktop HomePage tab Customer Journey displayed
        /// </summary>
        public void VerifyFinesseDesktopCustomerJourneyTab()
        {
            seleLibs.PageShouldContainElement(XPATH_BTN_REFRESH);
            seleLibs.PageShouldContainElement(XPATH_TABLE_JOURNEY);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_DATE);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_TIME);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_CALLER_ID);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_AGENT_ID);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_CALL_DISPOSTITION);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_MAIN);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_SUB1);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_SUB2);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_POLICY_NO);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_NRIC);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_CALL_FROM);
            seleLibs.PageShouldContainElement(XPATH_TABLE_HEADER_FREE_TEXT_MSG);
            seleLibs.PageShouldContainElement(XPATH_TABLE_JOURNEY_BODY);
            seleLibs.PageShouldContainElement(XPATH_BTN_1);
            seleLibs.PageShouldContainElement(XPATH_BTN_2);
            seleLibs.PageShouldContainElement(XPATH_BTN_3);
            seleLibs.PageShouldContainElement(XPATH_BTN_4);

        } 
    }
}