using Csharp_selenium_specflow_nunit.PageObjects;
using OpenQA.Selenium;

namespace Csharp_selenium_specflow_nunit.PageObjects.AIA
{
    public class FinesseDesktopWrapUpTab : BasePObject
    {
        // Main reason Checkboxs
        string XPATH_LBL_COMPLETED = "XPATH=.//label[text()='Completed']/parent::span";
        string XPATH_CKB_COMPLETED = "XPATH=.//label[text()='Completed']/preceding-sibling::input";
        string XPATH_LBL_COMPLETED_SMS = "XPATH=.//label[text()='Completed with SMS']/parent::span";
        string XPATH_CKB_COMPLETED_SMS = "XPATH=.//label[text()='Completed with SMS']/preceding-sibling::input";
        string XPATH_LBL_ESCALATION = "XPATH=.//label[text()='Escalation']/parent::span";
        string XPATH_CKB_ESCALATION = "XPATH=.//label[text()='Escalation']/preceding-sibling::input";
        string XPATH_LBL_ESCALATION_SMS = "XPATH=.//label[text()='Escalation with SMS']/parent::span";
        string XPATH_CKB_ESCALATION_SMS = "XPATH=.//label[text()='Escalation with SMS']/preceding-sibling::input";

        // Reason Checkboxs
        string XPATH_LBL_CLAIM_APPEAL = "XPATH=.//label[text()='Claim Appeal']/parent::span";
        string XPATH_CKB_CLAIM_APPEAL = "XPATH=.//label[text()='Claim Appeal']/preceding-sibling::input";
        string XPATH_LBL_BENEFIT_ENTITLEMENT = "XPATH=.//label[text()='Benefit Entitlement']/parent::span";
        string XPATH_CKB_BENEFIT_ENTITLEMENT = "XPATH=.//label[text()='Benefit Entitlement']/preceding-sibling::input";
        string XPATH_LBL_CLAIM_PROCEDURE = "XPATH=.//label[text()='Claim Procedure']/parent::span";
        string XPATH_CKB_CLAIM_PROCEDURE = "XPATH=.//label[text()='Claim Procedure']/preceding-sibling::input";
        string XPATH_LBL_CLAIM_SUBMISSION = "XPATH=.//label[text()='Claim Submission']/parent::span";
        string XPATH_CKB_CLAIM_SUBMISSION = "XPATH=.//label[text()='Claim Submission']/preceding-sibling::input";
        string XPATH_LBL_CLAIM_STATUS = "XPATH=.//label[text()='Claim Status']/parent::span";
        string XPATH_CKB_CLAIM_STATUS = "XPATH=.//label[text()='Claim Status']/preceding-sibling::input";
        string XPATH_LBL_CLAIM_COMPUTATION = "XPATH=.//label[text()='Claims Computation']/parent::span";
        string XPATH_CKB_CLAIM_COMPUTATION = "XPATH=.//label[text()='Claims Computation']/preceding-sibling::input";
        string XPATH_LBL_EBENEFITS_MOBILE_APP = "XPATH=.//label[text()='Ebenefits & Mobile Apps']/parent::span";
        string XPATH_CKB_EBENEFITS_MOBILE_APP = "XPATH=.//label[text()='Ebenefits & Mobile Apps']/preceding-sibling::input";
        string XPATH_LBL_LOG_ECP = "XPATH=.//label[text()='LOG / ECP']/parent::span";
        string XPATH_CKB_LOG_ECP = "XPATH=.//label[text()='LOG / ECP']/preceding-sibling::input";
        string XPATH_LBL_MEMBER_ADMINISTRATION = "XPATH=.//label[text()='Member Administration']/parent::span";
        string XPATH_CKB_MEMBER_ADMINISTRATION = "XPATH=.//label[text()='Member Administration']/preceding-sibling::input";
        string XPATH_LBL_PAYMENT_ENQUIRY = "XPATH=.//label[text()='Payment Enquiry']/parent::span";
        string XPATH_CKB_PAYMENT_ENQUIRY = "XPATH=.//label[text()='Payment Enquiry']/preceding-sibling::input";
        string XPATH_LBL_REQUEST_LETTERS_DOCS = "XPATH=.//label[text()='Request Letters/Docs']/parent::span";
        string XPATH_CKB_REQUEST_LETTERS_DOCS = "XPATH=.//label[text()='Request Letters/Docs']/preceding-sibling::input";
        string XPATH_LBL_REPEATED = "XPATH=.//label[text()='Repeated']/parent::span";
        string XPATH_CKB_REPEATED = "XPATH=.//label[text()='Repeated']/preceding-sibling::input";
        string XPATH_LBL_OTHERS = "XPATH=.//label[text()='Others']/parent::span";
        string XPATH_CKB_OTHERS = "XPATH=.//label[text()='Others']/preceding-sibling::input";

        // Sub Checkboxs "Claim Appeal"
        string XPATH_LBL_ACCEPT_CTC_BILL = "XPATH=.//label[text()='Accept CTC Bill']/parent::span";
        string XPATH_CKB_ACCEPT_CTC_BILL = "XPATH=.//label[text()='Accept CTC Bill']/preceding-sibling::input";


        // Define locators - NRIC & POLICY NO
        string XPATH_LBL_NRIC = "XPATH=.//span[text()='NRIC']";
        string XPATH_TXT_NRIC = "XPATH=.//span[text()='NRIC']/parent::td/following-sibling::td/input";
        string XPATH_LBL_POLICY_NO = "XPATH=.//span[text()='Policy No']";
        string XPATH_TXT_POLICY_NO = "XPATH=.//span[text()='Policy No']/parent::td/following-sibling::td/input";
        string XPATH_LBL_AGENT_ID = "XPATH=.//span[text()='Agent ID']";
        string XPATH_TXT_AGENT_ID = "XPATH=.//span[text()='Agent ID']/parent::td/following-sibling::td/input";
        string XPATH_LBL_COMPANY_NAME = "XPATH=.//span[text()='Company Name']";
        string XPATH_TXT_COMPANY_NAME = "XPATH=.//span[text()='Company Name']/parent::td/following-sibling::td/input";
        string XPATH_LBL_CALLED_FORM = "XPATH=.//span[text()='Called From']";
        string XPATH_DRP_CALLED_FORM = "XPATH=.//select[@class='form-control']";
        string XPATH_LBL_FREE_TEXT = "XPATH=.//span[text()='Free Text']";
        string XPATH_TXT_FREE_TEXT = "XPATH=.//span[text()='Free Text']/parent::td/following-sibling::td//textarea";

        // Define locators - Buttons
        string XPATH_BTN_SUBMIT = "XPATH=.//button[text()='Submit']";
        string XPATH_BTN_START_INTERACTION = "XPATH=.//button[text()='Start Interaction']";
        string XPATH_BTN_END_INTERACTION = "XPATH=.//button[text()='End Interaction']";
        string XPATH_BTN_WRAP_UP = "XPATH=.//button[text()='Wrap Up']";

        // Define locators - Table Submit
        string XPATH_TABLE_TR_MAIN = "XPATH=.//td[text()=' main']";
        string XPATH_TABLE_TR_SUB_1A = "XPATH=.//td[text()=' sub1a']";
        string XPATH_TABLE_TR_SUB_1B = "XPATH=.//td[text()=' sub1b']";
        string XPATH_TABLE_TR_SUB_1C = "XPATH=.//td[text()=' sub1c']";
        string XPATH_TABLE_TR_SUB_2AA = "XPATH=.//td[text()=' sub2aa']";
        string XPATH_TABLE_TR_SUB_2AB = "XPATH=.//td[text()=' sub2ab']";
        string XPATH_TABLE_TR_SUB_2AC = "XPATH=.//td[text()=' sub2ac']";
        string XPATH_TABLE_TR_SUB_2BA = "XPATH=.//td[text()=' sub2ba']";
        string XPATH_TABLE_TR_SUB_2BB = "XPATH=.//td[text()=' sub2bb']";
        string XPATH_TABLE_TR_SUB_2BC = "XPATH=.//td[text()=' sub2bc']";
        string XPATH_TABLE_TR_SUB_2CA = "XPATH=.//td[text()=' sub2ca']";
        string XPATH_TABLE_TR_SUB_2CB = "XPATH=.//td[text()=' sub2cb']";
        string XPATH_TABLE_TR_SUB_2CC = "XPATH=.//td[text()=' sub2cc']";
        string XPATH_TABLE_TR_WRAPUPNRIC = "XPATH=.//td[text()=' wrapupnric']";
        string XPATH_TABLE_TR_WRAPUPPOLNO = "XPATH=.//td[text()=' wrapuppolno']";
        string XPATH_TABLE_TR_WRAPUPCALLEDFROM = "XPATH=.//td[text()=' wrapupcalledfrom']";
        string XPATH_TABLE_TR_WRAPUPFREETEXT = "XPATH=.//td[text()=' wrapupfreetext']";
        string XPATH_TABLE_TR_AGENTID = "XPATH=.//td[text()=' agentid']";
        string XPATH_TABLE_TR_CNYNAME = "XPATH=.//td[text()=' cnyname']";


        public FinesseDesktopWrapUpTab(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Verify Finesse Desktop HomePage tab Call Info displayed
        /// </summary>
        public void VerifyFinesseDesktopCallInfoTab()
        {
            seleLibs.PageShouldContainElement(XPATH_LBL_COMPLETED);
            seleLibs.PageShouldContainElement(XPATH_CKB_COMPLETED);
            seleLibs.PageShouldContainElement(XPATH_LBL_COMPLETED_SMS);
            seleLibs.PageShouldContainElement(XPATH_CKB_COMPLETED_SMS);
            seleLibs.PageShouldContainElement(XPATH_LBL_ESCALATION);
            seleLibs.PageShouldContainElement(XPATH_CKB_ESCALATION);
            seleLibs.PageShouldContainElement(XPATH_LBL_ESCALATION_SMS);
            seleLibs.PageShouldContainElement(XPATH_CKB_ESCALATION_SMS);

            seleLibs.PageShouldContainElement(XPATH_LBL_CLAIM_APPEAL);
            seleLibs.PageShouldContainElement(XPATH_CKB_CLAIM_APPEAL);
            seleLibs.PageShouldContainElement(XPATH_LBL_BENEFIT_ENTITLEMENT);
            seleLibs.PageShouldContainElement(XPATH_CKB_BENEFIT_ENTITLEMENT);
            seleLibs.PageShouldContainElement(XPATH_LBL_CLAIM_PROCEDURE);
            seleLibs.PageShouldContainElement(XPATH_CKB_CLAIM_PROCEDURE);
            seleLibs.PageShouldContainElement(XPATH_LBL_CLAIM_SUBMISSION);
            seleLibs.PageShouldContainElement(XPATH_CKB_CLAIM_SUBMISSION);
            seleLibs.PageShouldContainElement(XPATH_LBL_CLAIM_STATUS);
            seleLibs.PageShouldContainElement(XPATH_CKB_CLAIM_STATUS);
            seleLibs.PageShouldContainElement(XPATH_LBL_CLAIM_COMPUTATION);
            seleLibs.PageShouldContainElement(XPATH_CKB_CLAIM_COMPUTATION);
            seleLibs.PageShouldContainElement(XPATH_LBL_EBENEFITS_MOBILE_APP);
            seleLibs.PageShouldContainElement(XPATH_CKB_EBENEFITS_MOBILE_APP);
            seleLibs.PageShouldContainElement(XPATH_LBL_LOG_ECP);
            seleLibs.PageShouldContainElement(XPATH_CKB_LOG_ECP);
            seleLibs.PageShouldContainElement(XPATH_LBL_MEMBER_ADMINISTRATION);
            seleLibs.PageShouldContainElement(XPATH_CKB_MEMBER_ADMINISTRATION);
            seleLibs.PageShouldContainElement(XPATH_LBL_PAYMENT_ENQUIRY);
            seleLibs.PageShouldContainElement(XPATH_CKB_PAYMENT_ENQUIRY);
            seleLibs.PageShouldContainElement(XPATH_LBL_REQUEST_LETTERS_DOCS);
            seleLibs.PageShouldContainElement(XPATH_CKB_REQUEST_LETTERS_DOCS);
            seleLibs.PageShouldContainElement(XPATH_LBL_REPEATED);
            seleLibs.PageShouldContainElement(XPATH_CKB_REPEATED);
            seleLibs.PageShouldContainElement(XPATH_LBL_OTHERS);
            seleLibs.PageShouldContainElement(XPATH_CKB_OTHERS);


            seleLibs.PageShouldContainElement(XPATH_LBL_NRIC);
            seleLibs.PageShouldContainElement(XPATH_TXT_NRIC);
            seleLibs.PageShouldContainElement(XPATH_LBL_POLICY_NO);
            seleLibs.PageShouldContainElement(XPATH_TXT_POLICY_NO);
            seleLibs.PageShouldContainElement(XPATH_LBL_AGENT_ID);
            seleLibs.PageShouldContainElement(XPATH_TXT_AGENT_ID);
            seleLibs.PageShouldContainElement(XPATH_LBL_COMPANY_NAME);
            seleLibs.PageShouldContainElement(XPATH_TXT_COMPANY_NAME);
            seleLibs.PageShouldContainElement(XPATH_LBL_CALLED_FORM);
            seleLibs.PageShouldContainElement(XPATH_DRP_CALLED_FORM);
            seleLibs.PageShouldContainElement(XPATH_LBL_FREE_TEXT);
            seleLibs.PageShouldContainElement(XPATH_TXT_FREE_TEXT);

            seleLibs.PageShouldContainElement(XPATH_BTN_SUBMIT);

            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_MAIN);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_1A);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_1B);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_1C);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2AA);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2AB);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2AC);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2BA);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2BB);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2BC);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2CA);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2CB);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_SUB_2CC);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_WRAPUPNRIC);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_WRAPUPPOLNO);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_WRAPUPCALLEDFROM);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_WRAPUPFREETEXT);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_AGENTID);
            seleLibs.PageShouldContainElement(XPATH_TABLE_TR_CNYNAME);
            seleLibs.PageShouldContainElement(XPATH_BTN_SUBMIT);

            seleLibs.PageShouldContainElement(XPATH_BTN_START_INTERACTION);
            seleLibs.PageShouldContainElement(XPATH_BTN_END_INTERACTION);
            seleLibs.PageShouldContainElement(XPATH_BTN_WRAP_UP);
        }
    }
}