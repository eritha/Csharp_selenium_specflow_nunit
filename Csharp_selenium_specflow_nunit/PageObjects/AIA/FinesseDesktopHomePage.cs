using Csharp_selenium_specflow_nunit.PageObjects;
using OpenQA.Selenium;

namespace Csharp_selenium_specflow_nunit.PageObjects.AIA
{
    public class FinesseDesktopHomePage : BasePObject
    {
        // Define locators - HOME
        string XPATH_ICON_CISCO = "XPATH=.//span[text()='Cisco Finesse']/preceding-sibling::*";
        string XPATH_TITLE_HOMEPAGE = "XPATH=.//span[text()='Cisco Finesse']";
        string ID_HMENU_DRP_VOICE_STATUS = "ID=voice-state-select-headerContainer";
        string ID_HMENU_ICO_CHAT = "ID=chat-icon";
        string ID_HMENU_ICO_PHONE_NEW_CALL = "ID=make-new-call-actionbutton";
        string ID_HMENU_IDENTITY = "ID=identity-menu";

        string XPATH_MENU_HOME = "XPATH=.//a[@title='Home']";
        string XPATH_MENU_MANAGE_CHAT_EMAIL = "XPATH=.//a[@title='Manage Chat and Email']";
        string XPATH_MENU_MY_HISTORY = "XPATH=.//a[@title='My History']";
        string XPATH_MENU_MANAGE_CUSTOMER = "XPATH=.//a[@title='Manage Customer']";

        // Define locators - TABS
        string ID_LBL_FINESSE_GADGET = "ID=finesse_gadget_0_title_text";
        string ID_LNK_TAB_CALL_INFO = "ID=ui-id-1";
        string ID_LNK_TAB_CUSTOMER_JOURNEY = "ID=ui-id-2";
        string ID_LNK_TAB_WRAP_UP = "ID=ui-id-3";

        public FinesseDesktopHomePage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Verify Finesse Desktop HomePage page displayed
        /// </summary>
        public void VerifyFinesseDesktopHomePage()
        {
            seleLibs.PageShouldContainElement(XPATH_ICON_CISCO);
            seleLibs.PageShouldContainElement(XPATH_TITLE_HOMEPAGE);
            seleLibs.PageShouldContainElement(ID_HMENU_DRP_VOICE_STATUS);
            seleLibs.PageShouldContainElement(ID_HMENU_ICO_CHAT);
            seleLibs.PageShouldContainElement(ID_HMENU_ICO_PHONE_NEW_CALL);
            seleLibs.PageShouldContainElement(ID_HMENU_IDENTITY);
            seleLibs.PageShouldContainElement(XPATH_MENU_HOME);
            seleLibs.PageShouldContainElement(XPATH_MENU_MANAGE_CHAT_EMAIL);
            seleLibs.PageShouldContainElement(XPATH_MENU_MY_HISTORY);
            seleLibs.PageShouldContainElement(XPATH_MENU_MANAGE_CUSTOMER);
        } 
    }
}