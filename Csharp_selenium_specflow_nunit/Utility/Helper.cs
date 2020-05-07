using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Csharp_selenium_specflow_nunit.Utility
{
    public class Helper
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        IJavaScriptExecutor jsDriver;

        public Helper(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(Constant.TIME_WAIT));
            jsDriver = (IJavaScriptExecutor)driver;
        }

        public enum EnumOsType
        {
            Windows,
            Linux,
            MacOS,
            Unknown
        }

        private String jsColorElementBorderBlue = "arguments[0].style=\'border: 1px solid; border-color: blue\'";
        private String jsColorElementBorderBlueRemove = "arguments[0].style=\'border: 0px solid; border-color: blue\'";
        private String jsColorElementBorderGreen = "arguments[0].style=\'border: 2px solid; border-color: green\'"; // Highlight when asserting data
        public class Constant
        {
            public static int TIME_IMPLICITWAIT = 10;
            public static int TIME_WAIT = 60;
            public static int TIME_PAGELOADWAIT = 50;
            public static int TIME_ASYNJAVASCRIPTWAIT = 30;
        }

        public IWebElement FindElement(String locator)
        {
            try
            {
                IWebElement ele = driver.FindElement(ByLocator(locator));

                HighlightElement(ele, jsColorElementBorderBlue);
                Thread.Sleep(300);
                HighlightElement(ele, jsColorElementBorderBlueRemove); // Remove highlight
                return ele;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element NOT found : " + locator);
                Console.WriteLine("Class Helper | Method FindElement | Exception desc : " + ex.Message);
                return null;
            }
        }

        public IList<IWebElement> FindElements(String locator)
        {
            try
            {
                IList<IWebElement> eles = driver.FindElements(ByLocator(locator));

                int i = 0;
                foreach (IWebElement ele in eles)
                {
                    HighlightElement(ele, jsColorElementBorderBlue);
                    Console.WriteLine("Element [" + i + "] >>> " + ele.ToString());
                    i++;
                    Thread.Sleep(300);
                    HighlightElement(ele, jsColorElementBorderBlueRemove);
                }
                return eles;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Class Helper | Method FindElements | Exception desc : " + ex.Message);
                return null;
            }
        }

        public IWebElement FindElementAssert(String locator)
        {
            try
            {
                IWebElement ele = driver.FindElement(ByLocator(locator));

                HighlightElement(ele, jsColorElementBorderBlue);
                Thread.Sleep(300);
                HighlightElement(ele, jsColorElementBorderGreen);
                return ele;
            }
            catch (NotFoundException ex)
            {
                Console.WriteLine("Element NOT found : " + locator);
                Console.WriteLine("Class Helper | Method FindElement | Exception desc : " + ex.Message);
                return null;
            }
        }

        private void HighlightElement(IWebElement ele, String style)
        {
            try
            {
                jsDriver.ExecuteScript(style, new object[] { ele });
            }
            catch (ElementNotInteractableException ex)
            {
                Console.WriteLine("Class Helper | Method HighlightElement | Exception desc : " + ex.Message);
            }
        }

        private void HighlightElementData(IWebElement ele)
        {
            try
            {
                jsDriver.ExecuteScript(jsColorElementBorderGreen, new object[] { ele });
            }
            catch (ElementNotInteractableException ex)
            {
                Console.WriteLine("Class Helper | Method RemoveHighlightElement | Exception desc : " + ex.Message);
            }
        }
        private By ByLocator(String selectorTypeStr, String value)
        {
            By element = null;
            //UISelectorType selector = UISelectorType.fromString(selectorTypeStr);
            switch (selectorTypeStr.ToLower())
            {
                case "id":
                    element = By.Id(value);
                    break;
                case "text_contains":
                    element = By.XPath("//*[contains(text(),\'" + value + "\')]");
                    break;
                case "text":
                    element = By.XPath("//*[text() = \'" + value + "\']");
                    break;
                case "text_start_with":
                    element = By.XPath("//*[starts-with(text(), \'" + value + "\')]");
                    break;
                case "class_name":
                    element = By.ClassName(value);
                    break;
                case "xpath":
                    element = By.XPath(value);
                    break;
                case "css":
                    element = By.CssSelector(value);
                    break;
                case "name":
                    element = By.Name(value);
                    break;
                case "link_text":
                    element = By.LinkText(value);
                    break;
                case "tag_name":
                    element = By.TagName(value);
                    break;

            }
            return element;
        }

        public By ByLocator(String locator)
        {
            try
            {
                var element = this.ByLocator(this.SplitLocator(locator)[0], this.SplitLocator(locator)[1]);
                return element;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Helper | Method byLocator | Exception desc: " + ex.Message);
                return null;
            }

        }

        public String[] SplitLocator(String str)
        {
            try
            {
                //String[] parts = str.Split('=');
                String[] parts = str.Split(new char[] { '=' }, 2);
                return parts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Class Helper | Method Split | Exception desc : " + ex.Message);
                return null;
            }

        }

        public void InputText(String locator, String value)
        {
            try
            {
                FindElement(locator).SendKeys(value);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element exception : " + locator);
                Console.WriteLine("Class Helper | Method InputText | Exception desc : " + ex.Message);
            }
        }

        public void ClickElement(String locator)
        {
            try
            {
                FindElement(locator).Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element exception : " + locator);
                Console.WriteLine("Class Helper | Method ClickElement | Exception desc : " + ex.Message);
            }
        }

        public void ClickElementByIndex(String locator, int index)
        {
            try
            {
                FindElements(locator)[index: index].Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element exception : " + locator);
                Console.WriteLine("Class Helper | Method ClickElement | Exception desc : " + ex.Message);
            }
        }

        public void PressEnter(String locator)
        {
            try
            {
                FindElement(locator).SendKeys(Keys.Enter);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element exception : " + locator);
                Console.WriteLine("Class Helper | Method ClearElementText | Exception desc : " + ex.Message);
            }

        }
        public String GetTitle()
        {
            return FindElement("TAG_NAME=title").Text;
        }
        public String GetText(String locator)
        {
            return FindElement(locator).Text;
        }

        public String GetValue(String locator)
        {
            return FindElement(locator).GetAttribute("value");
        }

        public String GetAttribute(String locator, String attribute)
        {
            return FindElement(locator).GetAttribute(attribute);
        }

        public String GetTextElementsByIndex(String locator, int index)
        {
            IList<IWebElement> eles = FindElements(locator);
            return eles[index].Text;
        }

        public void ClearElementText(String locator)
        {
            try
            {
                FindElement(locator).Clear();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("No Such Element exception : " + locator);
                Console.WriteLine("Class Helper | Method ClearElementText | Exception desc : " + ex.Message);
            }
        }

        public void SelectDropdown(String locator, String value)
        {
            try
            {
                SelectElement drp = new SelectElement(FindElement(locator));
                drp.SelectByText(value);
            }
            catch (ElementNotSelectableException ex)
            {
                Console.WriteLine("Canot select value from element: " + locator);
                Console.WriteLine("Class Helper | Method SelectDropdown | Exception desc : " + ex.Message);
            }

        }

        public void WaitUntilElementIsVisible(String locator)
        {
            WebDriverWait waitVisible = new WebDriverWait(driver, TimeSpan.FromSeconds(Constant.TIME_WAIT));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(ByLocator(locator)));
        }

        public void WaitUntilPageContainElement(String locator)
        {
            WebDriverWait waitVisible = new WebDriverWait(driver, TimeSpan.FromSeconds(Constant.TIME_WAIT));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(ByLocator(locator)));
        }

        public Boolean ElementShouldBeEnabled(String locator)
        {
            Boolean isEnable = false;
            try
            {
                isEnable = FindElementAssert(locator).Enabled;
                Assert.IsTrue(isEnable);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Element is Disabled : " + locator);
                Console.WriteLine("Class Helper | Method ElementShouldBeEnabled | Exception desc : " + ex.Message);
            }
            return isEnable;
        }

        public Boolean ElementShouldBeDisabled(String locator)
        {
            Boolean isEnable = true;
            try
            {
                isEnable = FindElementAssert(locator).Enabled;
                Assert.IsFalse(isEnable);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Element is Enable : " + locator);
                Console.WriteLine("Class Helper | Method ElementShouldBeDisabled | Exception desc : " + ex.Message);
            }
            return isEnable;
        }

        public Boolean ElementShouldBeVisible(String locator)
        {
            Boolean isVisible = false;
            try
            {
                isVisible = FindElementAssert(locator).Displayed;
                Assert.IsTrue(isVisible);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Element is not Visible : " + locator);
                Console.WriteLine("Class Helper | Method ElementShouldBeVisible | Exception desc : " + ex.Message);
            }
            return isVisible;
        }

        public Boolean ElementShouldNotBeVisible(String locator)
        {
            Boolean isVisible = true;
            try
            {
                isVisible = FindElementAssert(locator).Displayed;
                Assert.IsFalse(isVisible);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Element is Visible : " + locator);
                Console.WriteLine("Class Helper | Method ElementShouldNotBeVisible | Exception desc : " + ex.Message);
            }
            return isVisible;
        }

        public void PageShouldContain(String value)
        {
            try
            {
                Assert.IsTrue(FindElementAssert("TEXT_CONTAINS=" + value) != null);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Page not contain TEXT: " + value);
                Console.WriteLine("Class Helper | Method PageShouldContain | Exception desc : " + ex.Message);
            }
        }
        public void PageShouldContainElement(String locator)
        {
            try
            {
                Assert.IsTrue(FindElementAssert(locator) != null);
            }
            catch (InvalidElementStateException ex)
            {
                Console.WriteLine("Page not contain element: " + locator);
                Console.WriteLine("Class Helper | Method PageShouldContainElement | Exception desc : " + ex.Message);
            }
        }

        public void ElementTextShouldBe(String locator, String value)
        {
            String actual = FindElementAssert(locator).Text;
            try
            {
                Assert.IsTrue(actual.Equals(value));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Text not equal:" + locator + "\n Expected: " + value + "\n Actual: " + actual);
                Console.WriteLine("Class Helper | Method ElementTextShouldBe | Exception desc : " + ex.Message);
            }
        }

        public void DropdownValueShouldBe(String locator, String value)
        {
            SelectElement drp = new SelectElement(FindElementAssert(locator));
            try
            {
                Assert.AreEqual(drp.SelectedOption.Text, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Text not equal:" + locator + "\n Expected: " + value + "\n Actual: " + drp.SelectedOption);
                Console.WriteLine("Class Helper | Method DropdownValueShouldBe | Exception desc : " + ex.Message);
            }
        }

        public void RadioButtonShouldBeChecked(String locator)
        {
            try
            {
                Assert.IsTrue(FindElementAssert(locator).Selected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element:" + locator + " is not checked");
                Console.WriteLine("Class Helper | Method RadioButtonShouldBeChecked | Exception desc : " + ex.Message);
            }
        }

        public void RadioButtonShouldNotBeChecked(String locator)
        {
            try
            {
                Assert.IsFalse(FindElementAssert(locator).Selected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Element:" + locator + " is checked");
                Console.WriteLine("Class Helper | Method RadioButtonShouldNotBeChecked | Exception desc : " + ex.Message);
            }
        }

        public void InputauthenticationPopupAndSubmit(String username, String password)
        {
            try
            {
                //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Constant.TIME_WAIT));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                alert.SetAuthenticationCredentials(username, password);
                alert.Accept();
            }
            catch (Exception ex)
            {
                Console.WriteLine("AlertIsPresent");
                Console.WriteLine("Class Helper | Method InputauthenticationPopupAndSubmit | Exception desc : " + ex.Message);
            }
        }

        //public bool WaitForAjax(this IWebDriver driver)
        //{
        //    try
        //    {
        //        while (true) // Handle timeout somewhere
        //        {
        //            var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
        //            if (ajaxIsComplete)
        //                break;
        //            Thread.Sleep(100);
        //        }
        //    }
        //    catch (TimeoutException e)
        //    {
        //        Console.Error.WriteLine(e.Message + "Error waiting for ajax");
        //    }

        //    return true;
        //}

        //public void executeJavascriptToElement(String locator)
        //{
        //    IWebElement element = this.FindElement(locator);
        //    JavascriptExecutor js = ((JavascriptExecutor)(driver));
        //    js.executeScript("arguments[0].click();", element);
        //}

        //public void executeJavascript(String javascript)
        //{
        //    JavascriptExecutor js = ((JavascriptExecutor)(driver));
        //    js.executeScript(javascript);
        //}

        //public void deleteValue(String locator)
        //{
        //    IWebElement element = this.FindElement(locator);
        //    element.sendKeys((Keys.CONTROL + "a"));
        //    element.sendKeys(Keys.DELETE);
        //} 

        //public bool isElementsPresent(String arrString)
        //{
        //    Boolean isElements = Boolean.FALSelement;
        //    try
        //    {
        //        String[] parts = arrString.split(",\n");
        //        foreach (String locator in parts)
        //        {
        //            //  get array
        //            //  get identify
        //            String identify = Objects.requireNonNull(this.split(locator))[2];
        //            //  get element on each array & higlight
        //            this.jsColorBorderElement = "arguments[0].style=\'border: 2px solid; border-color: green\'";
        //            IWebElement element = this.FindElement(locator);
        //            switch (identify)
        //            {
        //                case "checkExist":
        //                    LogUtils.info("");
        //                    isElements = (this.FindElements(locator).size() > 0);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkExist | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkSelected":
        //                    LogUtils.info("");
        //                    isElements = element.isSelected();
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkSelected | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkText":
        //                    LogUtils.info("");
        //                    String text = Objects.requireNonNull(this.split(locator))[3];
        //                    System.out.println(text);
        //                    System.out.println(("Text of this element: " + element.getText()));
        //                    isElements = element.getText().trim().equalsIgnoreCase(text);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkText | Exception desc : "
        //                                        + (locator + (" &&& text is: " + text))));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkURL":
        //                    LogUtils.info("");
        //                    isElements = driver.getCurrentUrl().equalsIgnoreCase(Objects.requireNonNull(this.split(locator))[3]);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkURL | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //            }
        //        }

        //        return;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementsPresent | Exception desc : " + e.getMessage()));
        //        return isElements;
        //    }

        //}

        //public bool isElementsPresent(String arrString, Object object)
        //{
        //    Boolean isElements = Boolean.FALSelement;
        //    try
        //    {
        //        String[] parts = arrString.split(",\n");
        //        foreach (String locator in parts)
        //        {
        //            //  get array
        //            //  get identify
        //            String identify = Objects.requireNonNull(this.split(locator))[2];
        //            //  get element on each array & higlight
        //            this.jsColorBorderElement = "arguments[0].style=\'border: 2px solid; border-color: green\'";
        //            IWebElement element = this.FindElement(locator);
        //            switch (identify)
        //            {
        //                case "checkExist":
        //                    LogUtils.info("");
        //                    isElements = (this.FindElements(locator).size() > 0);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkExist | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkSelected":
        //                    LogUtils.info("");
        //                    isElements = element.isSelected();
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkSelected | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkText":
        //                    LogUtils.info("");
        //                    String newText = this.invokeToMethod(object, Objects.requireNonNull(this.split(locator))[3]);
        //                    System.out.println(newText);
        //                    System.out.println(("Text of this element: " + element.getText()));
        //                    isElements = element.getText().trim().equalsIgnoreCase(newText);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkText | Exception desc : "
        //                                        + (locator + (" &&& text is: " + newText))));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkURL":
        //                    LogUtils.info("");
        //                    isElements = driver.getCurrentUrl().equalsIgnoreCase(Objects.requireNonNull(this.split(locator))[3]);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkURL | Exception desc : " + locator));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //                case "checkPlaceHolder":
        //                    LogUtils.info("");
        //                    String expectedText = this.invokeToMethod(object, Objects.requireNonNull(this.split(locator))[3]);
        //                    System.out.println(expectedText);
        //                    System.out.println(("Placeholder of this element: " + element.getAttribute("placeholder")));
        //                    isElements = element.getAttribute("placeholder").trim().equalsIgnoreCase(expectedText);
        //                    if (!isElements)
        //                    {
        //                        Result.checkFail(("Class Helper | Method isElementsPresent | Not able to found checkPlaceHolder | Exception desc : "
        //                                        + (locator + (" &&& text is: " + expectedText))));
        //                        break;
        //                    }
        //                    else
        //                    {
        //                        // TODO: Warning!!! continue Else
        //                    }

        //                    break;
        //            }
        //        }

        //        return;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementsPresent | Exception desc : " + e.getMessage()));
        //        return isElements;
        //    }

        //}

        ////  t�m �n method checkMultiLanguage � ch�y c�i method �
        //public String invokeToMethod(Object object, String compareText)
        //{
        //    String text = "";
        //    try
        //    {
        //        foreach (Method aMethod in method)
        //        {
        //            if (aMethod.getName().trim().equalsIgnoreCase("checkMultiLanguages"))
        //            {
        //                text = ((String)(aMethod.invoke(object, compareText)));
        //                break;
        //            }

        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method invokeToMethod | Exception desc : " + e.getMessage()));
        //    }
        //    catch (InvocationTargetException)
        //    {
        //    }

        //    IllegalAccessException exlement;
        //    ex.printStackTrace();
        //    return text;
        //}

        //public void backButton()
        //{
        //    try
        //    {
        //        driver.navigate().back();
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method backButton | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public void refreshPage()
        //{
        //    try
        //    {
        //        driver.navigate().refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method refreshPage | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public bool isElementEnable(String locator)
        //{
        //    try
        //    {
        //        bool isEnabled = driver.FindElement(this.byLocator(locator)).isEnabled();
        //        if (isEnabled)
        //        {
        //            this.addLog(("Element was enabled : " + locator));
        //            return truelement;
        //        }
        //        else
        //        {
        //            this.addLog(("Element was disabled : " + locator));
        //            return falselement;
        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementEnable | Exception desc : " + locator));
        //        return falselement;
        //    }

        //}

        //public bool isElementDisable(String locator)
        //{
        //    try
        //    {
        //        bool isEnabled = driver.FindElement(this.byLocator(locator)).isEnabled();
        //        if ((isEnabled == false))
        //        {
        //            this.addLog(("Element was disabled : " + locator));
        //            return truelement;
        //        }
        //        else
        //        {
        //            this.addLog(("Element was enabled : " + locator));
        //            return falselement;
        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("Element doesn\'t existed : " + locator));
        //        return falselement;
        //    }

        //}

        //public Boolean waitElementByID(String locationID)
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, 30);
        //    IWebElement element = this.wait.until(ExpectedConditions.presenceOfElementLocated(By.id(locationID)));
        //    return element.isEnabled();
        //}

        //public void waitElementIsDisplayed(String locator)
        //{
        //    IWebElement el = this.FindElement(locator);
        //    WebDriverWait wait = new WebDriverWait(driver, 30);
        //    this.wait.until(ExpectedConditions.elementToBeClickable(el));
        //}

        //public void compareTextFromList(String locator, String textCompare)
        //{
        //    List<IWebElement> list = this.FindElements(locator);
        //    for (int i = 0; (i < list.size()); i++)
        //    {
        //        String text = list.get(i).getText();
        //        if (text.equalsIgnoreCase(textCompare))
        //        {
        //            this.addLog(("Value is: "
        //                            + (text + "\nThis case is PASSED")));
        //            break;
        //        }

        //    }

        //}

        //public void compareTextFromList(By locator, String textCompare)
        //{
        //    List<IWebElement> list = driver.FindElements(locator);
        //    for (int i = 0; (i < list.size()); i++)
        //    {
        //        String text = list.get(i).getText();
        //        if (text.equalsIgnoreCase(textCompare))
        //        {
        //            this.addLog(("Compare: "
        //                            + (text + "\nThis case is passed")));
        //            break;
        //        }

        //    }

        //}

        //public String changeFormatDate(String date, String read, String write)
        //{
        //    String formattedDate = "";
        //    SimpleDateFormat readFormat = new SimpleDateFormat(read);
        //    SimpleDateFormat writeFormat = new SimpleDateFormat(write);
        //    try
        //    {
        //        formattedDate = writeFormat.format(readFormat.parse(date));
        //    }
        //    catch (ParseException ex)
        //    {
        //        ex.printStackTrace();
        //    }

        //    //  System.out.println(" ===== STEP =====> format: "+formattedDate);
        //    return formattedDatelement;
        //}

        //public Boolean elementTextShoudlBe(String locator, String value)
        //{
        //    IWebElement el = this.FindElement(locator);
        //    String actualValue = el.getText();
        //    return actualValue.equals(value);
        //}



        //public String getTextElementsFromMain(String mainBranch, int iMain, String subLocator)
        //{
        //    //  get text element from main branch --> then get sub branch
        //    List<IWebElement> list = this.FindElements(mainBranch);
        //    String getTextSubLocator = list.get(iMain).FindElement(this.byLocator(subLocator)).getText();
        //    //  System.out.println(" ===== STEP =====> - "+getTextSubLocator);
        //    return getTextSubLocator;
        //}

        //public bool checkDurationTime(String getDate, String getTime)
        //{
        //    Calendar calendarOfCurrentDate = Calendar.getInstance();
        //    Date currentDate = new Date();
        //    calendarOfCurrentDate.setTime(currentDate);
        //    String getDateTime = (getDate + (" " + getTime));
        //    System.out.println(" ===== STEP =====> -------------------------------------------------");
        //    DateFormat dateTimeFormat = new SimpleDateFormat("E, MMMM dd, yyyy hh:mm a", Locale.ENGLISH);
        //    Date compareDateTime = null;
        //    try
        //    {
        //        compareDateTime = dateTimeFormat.parse(getDateTime);
        //    }
        //    catch (ParseException ex)
        //    {
        //        ex.printStackTrace();
        //    }

        //    long MAX_DURATION = MILLISECONDS.convert(30, MINUTES);
        //    long duration = (compareDateTime.getTime() - currentDate.getTime());
        //    if ((duration <= MAX_DURATION))
        //    {
        //        System.out.println(" ===== STEP =====> return true");
        //        return truelement;
        //    }

        //    return falselement;
        //}

        //protected enumOsType getOsType()
        //{
        //    enumOsType osType = enumOsType.Unknown;
        //    String osname = System.getProperty("os.name").toLowerCase();
        //    if ((osname.contains("unix") || osname.contains("linux")))
        //    {
        //        osType = enumOsType.Linux;
        //    }
        //    else if (osname.contains("windows"))
        //    {
        //        osType = enumOsType.Windows;
        //    }
        //    else if (osname.contains("mac os"))
        //    {
        //        osType = enumOsType.MacOS;
        //    }

        //    return osTypelement;
        //}

        //public WebDriver getDriver()
        //{
        //    return driver;
        //}

        //public void addLog(String logmsg)
        //{
        //    Reporter.log((logmsg + "</br>"), true);
        //}

        //public void addErrorLog(String logmsg)
        //{
        //    Reporter.log(("<font color=\'red\'> "
        //                    + (logmsg + " </font></br>")), true);
        //}

        //public void addSuccessLog(String logmsg)
        //{
        //    Reporter.log(("<font color=\'green\'> "
        //                    + (logmsg + " </font></br>")), true);
        //}

        //public String randomString()
        //{
        //    String SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        //    StringBuilder salt = new StringBuilder();
        //    Random rnd = new Random();
        //    while ((salt.length() < 6))
        //    {
        //        //  length of the random string.
        //        int index = ((int)((rnd.nextFloat() * SALTCHARS.length())));
        //        salt.append(SALTCHARS.charAt(index));
        //    }

        //    String saltStr = salt.toString();
        //    return saltStr;
        //}

        ////  Return a random number in a range
        //public int getRandomIndexWithRange(int Min, int Max)
        //{
        //    int random = 0;
        //    try
        //    {
        //        (// TODO: Warning!!!! NULL EXPRESSION DETECTED...
        //         +nextInt(((Max - Min)
        //                        + 1)));
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method getRandomIndexWithRange | Exception desc : " + e.getMessage()));
        //        ex.printStackTrace();
        //    }

        //    return random;
        //}

        ////  Return a random number in size
        //public int getRandomIndex(int size)
        //{
        //    int random = 0;
        //    try
        //    {
        //        (// TODO: Warning!!!! NULL EXPRESSION DETECTED...
        //         +nextInt(size));
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method getRandomIndex | Exception desc : " + e.getMessage()));
        //        ex.printStackTrace();
        //    }

        //    return random;
        //}

        //public String randomNumber(int numberChars)
        //{
        //    String SALTCHARS = "1234567890";
        //    StringBuilder salt = new StringBuilder();
        //    Random rnd = new Random();
        //    while ((salt.length() < numberChars))
        //    {
        //        //  length of the random string.
        //        int index = ((int)((rnd.nextFloat() * SALTCHARS.length())));
        //        salt.append(SALTCHARS.charAt(index));
        //    }

        //    String saltStr = salt.toString();
        //    return saltStr;
        //}

        //public String randomChars(int numberChars)
        //{
        //    String SALTCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        //    StringBuilder salt = new StringBuilder();
        //    Random rnd = new Random();
        //    while ((salt.length() < numberChars))
        //    {
        //        //  length of the random string.
        //        int index = ((int)((rnd.nextFloat() * SALTCHARS.length())));
        //        salt.append(SALTCHARS.charAt(index));
        //    }

        //    String saltStr = salt.toString();
        //    return saltStr;
        //}

        //public void waitForAjax()
        //{
        //    System.err.println("Checking active ajax calls by calling jquery.active ...");
        //    try
        //    {
        //        if ((driver is JavascriptExecutor))
        //        {
        //            JavascriptExecutor jsDriver = ((JavascriptExecutor)(driver));
        //            for (int i = 0; (i < Constant.TIME_WAIT); i++)
        //            {
        //                Object numberOfAjaxConnections = jsdriver.executeScript("return jQuery.active");
        //                //  return should be a number
        //                if ((numberOfAjaxConnections is Long))
        //                {
        //                    Long n = ((Long)(numberOfAjaxConnections));
        //                    System.err.println(("Number of active jquery ajax calls: " + n));
        //                    break;
        //                }

        //                Thread.sleep(3000);
        //            }

        //        }
        //        else
        //        {
        //            System.err.println(("Web driver: "
        //                            + (driver + " cannot execute javascript")));
        //        }

        //    }
        //    catch (InterruptedException ex)
        //    {
        //        System.err.println(e);
        //    }

        //}

        //public void reloadPage()
        //{
        //    try
        //    {
        //        this.addLog("Reload current page");
        //        driver.navigate().refresh();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog("Can not reloadPage current page");
        //    }

        //}



        //public void clickClassName(String classname)
        //{
        //    //  waitForAjax();
        //    try
        //    {
        //        this.addLog(("Click : " + classname));
        //        this.FindElement(classname).click();
        //        //  waitForAjax();
        //        // 
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("No element exception : " + classname));
        //    }

        //}

        //public String getTextByXpath(String locator)
        //{
        //    String text = "";
        //    try
        //    {
        //        text = this.FindElement(locator).getText();
        //        this.addLog(("Text : " + text));
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException at getTextByXpath :  " + locator));
        //    }

        //    return text;
        //}

        //public String jsID(String Id)
        //{
        //    String text = "";
        //    try
        //    {
        //        IWebElement btn = ((IWebElement)(((JavascriptExecutor)(driver)).executeScript("return document.getElementById(Id)")));
        //        text = btn.getText();
        //        this.addLog(("Text : " + text));
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException at getTextByjsID :  " + Id));
        //    }

        //    return text;
        //}

        //public Boolean isElementPresent(String locator)
        //{
        //    Boolean isPresent = Boolean.FALSelement;
        //    try
        //    {
        //        this.jsColorBorderElement = "arguments[0].style=\'border: 2px solid; border-color: green\'";
        //        isPresent = (this.FindElements(locator).size() > 0);
        //        return isPresent;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementPresent | Exception desc : " + ex.getMessage()));
        //        return isPresent;
        //    }

        //}

        //public Boolean isElementNotPresent(String locator)
        //{
        //    Boolean isPresent = Boolean.FALSelement;
        //    try
        //    {
        //        this.jsColorBorderElement = "arguments[0].style=\'border: 2px solid; border-color: green\'";
        //        isPresent = (this.FindElements(locator).size() == 0);
        //        return isPresent;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementNotPresent | Exception desc : " + ex.getMessage()));
        //        return isPresent;
        //    }

        //}

        //public Boolean isElementSelected(String locator)
        //{
        //    Boolean isSelected = Boolean.FALSelement;
        //    try
        //    {
        //        System.out.print((locator + ("\n>>> DEBUG CHECKBOX STATUS >>>>>CHECKED>>>>:" + this.FindElement(locator).getAttribute("checked"))));
        //        String expected = this.FindElement(locator).getAttribute("checked");
        //        Assert.assertEquals(expected, "true");
        //        return truelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementSelected | Exception desc : "
        //                        + (locator + ("\n" + ex.getMessage()))));
        //        return falselement;
        //    }

        //}

        //public Boolean isElementUnSelected(String locator)
        //{
        //    try
        //    {
        //        System.out.print((locator + ("\n>>> DEBUG CHECKBOX STATUS >>>>>UNCHECKED>>>>:" + this.FindElement(locator).getAttribute("checked"))));

        //        String expected = this.FindElement(locator).getAttribute("checked");
        //        Assert.assertNotEquals(expected, "true");
        //        return truelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Result.checkFail(("Class Helper | Method isElementUnSelected | Exception desc : "
        //                        + (locator + ("\n" + ex.getMessage()))));
        //        return falselement;
        //    }

        //}

        //public bool isElementPresent(IWebElement element)
        //{
        //    try
        //    {
        //        if ((element == null))
        //        {
        //            return falselement;
        //        }

        //        bool isDisplayed = element.isDisplayed();
        //        if (isDisplayed)
        //        {
        //            this.addLog(("Element displayed : " + element.getText()));
        //            return truelement;
        //        }
        //        else
        //        {
        //            this.addLog(("Element doesn\'t existed : " + element.getText()));
        //            return falselement;
        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException on isElementPresent " + element.getText()));
        //        return falselement;
        //    }

        //}

        //public void scrollByVisibleElement(IWebElement element)
        //{
        //    try
        //    {
        //        //  Create instance of Javascript executor
        //        JavascriptExecutor je = ((JavascriptExecutor)(driver));
        //        //  now execute query which actually will scroll until that element is not
        //        //  appeared on page.
        //        je.executeScript("arguments[0].scrollIntoView(true);", element);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method scrollByVisibleElement | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public void scrollByPixel(int xPixel, int yPixel)
        //{
        //    try
        //    {
        //        //  Create instance of Javascript executor
        //        JavascriptExecutor je = ((JavascriptExecutor)(driver));
        //        //  This will scroll down the page by 1000 pixel vertical
        //        je.executeScript(("window.scrollBy(" + xPixel), (yPixel + ")"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method scrollByPixel | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public void scrollDownByPage()
        //{
        //    try
        //    {
        //        //  Create instance of Javascript executor
        //        JavascriptExecutor je = ((JavascriptExecutor)(driver));
        //        //  This will scroll the web page till end.
        //        je.executeScript("window.scrollTo(0, document.body.scrollHeight)");
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method scrollDownByPage | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public void scrollUpByPage()
        //{
        //    try
        //    {
        //        //  Create instance of Javascript executor
        //        JavascriptExecutor je = ((JavascriptExecutor)(driver));
        //        //  This will scroll the web page till end.
        //        je.executeScript("window.scrollTo(document.body.scrollHeight, 0)");
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method scrollUpByPage | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public String getTextByXpath(IWebElement element)
        //{
        //    try
        //    {
        //        //  waitForAjax();
        //        String text = element.getText();
        //        this.addLog(("Text : " + text));
        //        return text;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException at getTextByXpath : " + element));
        //    }

        //    return "";
        //}

        ////  -----------------------methods from homeController
        //public bool isLinkExist(String locator)
        //{
        //    try
        //    {
        //        String isHref = this.FindElement(locator).getAttribute("href");
        //        if ((isHref != null))
        //        {
        //            return truelement;
        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.out.println(("NoSuchElementException" + locator));
        //    }

        //    return falselement;
        //}

        //public void editData(IWebElement element, String data)
        //{
        //    try
        //    {
        //        //  waitForAjax();
        //        element.clear();
        //        this.addLog(("change data : " + data));
        //        element.sendKeys(data);
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException at editData :  " + element));
        //    }

        //}

        //public String clickOptionByIndex(String locator, int indexNumber)
        //{
        //    try
        //    {
        //        this.waitForAjax();
        //        IWebElement dropDownListBox = driver.FindElement(this.byLocator(locator));
        //        Select clickThis = new Select(dropDownListBox);
        //        System.out.print(clickThis);
        //        this.addLog(("click : item index " + indexNumber));
        //        clickThis.selectByIndex(indexNumber);
        //        String textSelected = this.getItemSelected(locator);
        //        this.addLog(("click : " + textSelected));
        //        //  wait data loading
        //        //  waitForAjax();
        //        return textSelected;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addErrorLog("No such element exception");
        //    }

        //    return "";
        //}

        //public String getItemSelected(String xpath)
        //{
        //    return this.readField(xpath);
        //}

        //public String readField(String locator)
        //{
        //    try
        //    {
        //        //  waitForAjax();
        //        IWebElement footer = driver.FindElement(this.byLocator(locator));
        //        List<IWebElement> columns = footer.FindElements(By.tagName("option"));
        //        foreach (IWebElement column in columns)
        //        {
        //            if (column.isSelected())
        //            {
        //                String selected = column.getText();
        //                this.addLog(("Item selected : " + selected));
        //                return selected;
        //            }

        //        }

        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println(("NoSuchElementException at readField : " + locator));
        //    }

        //    return "";
        //}

        //public int getPageSize(String locator)
        //{
        //    try
        //    {
        //        String text = "";
        //        if ((this.FindElements(locator).size() > 0))
        //        {
        //            text = this.FindElement(locator).getText();
        //        }

        //        this.addLog(("page size text: " + text));
        //        int size = StringUtils.getPageSize(text);
        //        return sizelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addErrorLog("-------NoSuchElementException------- : getPageSize");
        //    }

        //    return 0;
        //}



        //public void clickHref(String href)
        //{
        //    try
        //    {
        //        //  waitForAjax();
        //        this.addLog(("Click : " + href));
        //        //  Thread.sleep(2000);
        //        driver.FindElement(By.cssSelector(href)).click();
        //        //  href example: "a[href*='long']"
        //        //  Thread.sleep(1000);
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println(("No element exception : " + href));
        //    }

        //    //  catch (InterruptedException ex) {
        //    //  ex.printStackTrace();
        //    //  }
        //}

        //public void navigateToUrl(String url)
        //{
        //    try
        //    {
        //        //  waitForAjax();
        //        this.addLog(("Navigate to : " + url));
        //        //  Thread.sleep(2000);
        //        driver.navigate().to(url);
        //        //  href example: "a[href*='long']"
        //        //  Thread.sleep(1000);
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println(("No element exception : " + url));
        //    }

        //    //  catch (InterruptedException ex) {
        //    //  ex.printStackTrace();
        //    //  }
        //}

        //public void assertBackGroundColor(String name, String verify)
        //{
        //    try
        //    {
        //        this.waitForAjax();
        //        this.addLog(("get background color : " + name));
        //        //  Thread.sleep(2000);
        //        //  ing color =
        //        //  driver.FindElement(By.name("btnK")).getCssValue("background-color");
        //        String color = driver.FindElement(By.name(name)).getCssValue("background-color");
        //        System.out.println(("color is " + color));
        //        Assert.assertEquals(verify, color);
        //        //  driver.navigate().to(url);
        //        //  href example: "a[href*='long']"
        //        //  Thread.sleep(1000);
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println(("No element exception : " + name));
        //    }

        //    //  catch (InterruptedException ex) {
        //    //  ex.printStackTrace();
        //    //  }
        //}



        //public void editData(String editXpath, String data)
        //{
        //    if ((data != null))
        //    {
        //        try
        //        {
        //            //  waitForAjax();
        //            IWebElement element = driver.FindElement(By.xpath(editXpath));
        //            //  note: work around because element.clear() wont' work in some cases
        //            element.sendKeys(Keys.BACK_SPACE);
        //            element.sendKeys(Keys.BACK_SPACE);
        //            element.clear();
        //            this.addLog(("change data : " + data));
        //            //  driver.FindElement(By.xpath(editXpath)).sendKeys(data);
        //            element.sendKeys(data);
        //            //  waitForAjax();
        //        }
        //        catch (NoSuchElementException ex)
        //        {
        //            Result.checkFail(("Class Helper | Method editData | Exception desc : " + e.getMessage()));
        //        }

        //    }

        //}

        //public void selectConfirmationDialogOption(String option)
        //{
        //    try
        //    {
        //        Thread.sleep(3000);
        //        this.addLog(("Select option: " + option));
        //        this.FindElement(("xpath:://*[@href=\'javascript:;\' and text() = \'"
        //                        + (option + "\']"))).click();
        //        Thread.sleep(2000);
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog("No such element exception");
        //    }
        //    catch (InterruptedException ex)
        //    {
        //        ex.printStackTrace();
        //    }

        //}

        ////  public void click(IWebElement element) {
        ////  try {
        ////  addLog("Click element: //*[@id=" + element.getAttribute("id") + "]");
        ////  element.click();
        ////  //waitForAjax();
        ////  } catch (NoSuchElementException ex) {
        ////  addLog("Element: " + element + " is not present");
        ////  }
        ////  }
        //public bool waitForElementClickable(String locator)
        //{
        //    try
        //    {
        //        this.addLog(("Wait for element: "
        //                        + (locator + " clickable")));
        //        this.wait.until(ExpectedConditions.elementToBeClickable(this.byLocator(locator)));
        //        return truelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("No such element: " + locator));
        //        return falselement;
        //    }

        //}

        //public bool waitForElementDisappear(String locator)
        //{
        //    try
        //    {
        //        this.addLog(("Wait for element: "
        //                        + (locator + " disappear")));
        //        this.wait.until(ExpectedConditions.invisibilityOfElementLocated(this.byLocator(locator)));
        //        return truelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("No such element: " + locator));
        //        return falselement;
        //    }

        //}

        //public bool checkMessageDisplay(String message)
        //{
        //    String text = driver.getPageSource();
        //    if (text.contains(message))
        //    {
        //        this.addLog(("Message: "
        //                        + (message + " found")));
        //        return truelement;
        //    }
        //    else
        //    {
        //        this.addLog(("Message: "
        //                        + (message + " not found")));
        //        return falselement;
        //    }

        //}

        //public int getTotalItem(String xpath)
        //{
        //    try
        //    {
        //        String text = this.getTextByXpath(xpath);
        //        return StringUtils.getNumAtIndex(text, 2);
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println("No element exception : getTotalItem");
        //    }

        //    return 0;
        //}

        //public int getPerPage(String xpath)
        //{
        //    try
        //    {
        //        String text = this.getTextByXpath(xpath);
        //        return StringUtils.getNumAtIndex(text, 1);
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        System.err.println("No element exception : getPerPage");
        //    }

        //    return 0;
        //}

        ////  TODO move to wrapper class
        //public bool selectACheckbox(String locator)
        //{
        //    try
        //    {
        //        IWebElement checkbox = driver.FindElement(this.byLocator(locator));
        //        if (!checkbox.isSelected())
        //        {
        //            this.addLog(("Select checkbox: " + locator));
        //            checkbox.click();
        //            //  waitForAjax();
        //            return truelement;
        //        }

        //        this.addLog(("Checkbox: "
        //                        + (locator + " is already selected")));
        //        return truelement;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("No such element: " + locator));
        //        return falselement;
        //    }

        //}

        //public void clickid(String id)
        //{
        //    //  TODO Auto-generated method stub
        //    //  waitForAjax();
        //    try
        //    {
        //        this.addLog(("Click : " + id));
        //        driver.FindElement(By.xpath(id)).click();
        //        //  waitForAjax();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("No element exception : " + id));
        //        Assert.assertTrue(false);
        //    }

        //}

        //public void typeid(String id, String data)
        //{
        //    //  TODO Auto-generated method stub
        //    try
        //    {
        //        //  waitForAjax();
        //        driver.FindElement(By.id(id)).clear();
        //        this.addLog(("change data : " + data));
        //        driver.FindElement(By.id(id)).sendKeys(data);
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("NoSuchElementException at editData :  " + id));
        //    }

        //}

        //public String gettextelementbytagname(String tagname)
        //{
        //    try
        //    {
        //        IWebElement IWebElement = driver.FindElement(By.tagName(tagname));
        //        this.addLog("Element is get successful ");
        //        String text = IWebElement.getText();
        //        this.addLog(("Text : " + text));
        //        return text;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog("NoSuchElementException: Element was not exist ");
        //    }

        //    return "";
        //}

        //public static int randBetween(int start, int end)
        //{
        //    return (start + ((int)(Math.round((Math.random()
        //                    * (end - start))))));
        //}

        //public String randomDataOfBirth(int yearStartInclusive, int yearEndExclusive)
        //{
        //    LocalDate start = LocalDate.ofYearDay(yearStartInclusive, 1);
        //    LocalDate end = LocalDate.ofYearDay(yearEndExclusive, 1);
        //    long longDays = ChronoUnit.DAYS.between(start, end);
        //    int days = ((int)(longDays));
        //    if ((days != longDays))
        //    {
        //        throw new IllegalStateException("int overflow; too many years");
        //    }

        //    int day = Helper.randBetween(0, days);
        //    LocalDate dateOfBirth = start.plusDays(day);
        //    return dateOfBirth.toString();
        //}

        //public String takeScreenshot(String Project, String ClassNames, String Result, String TCsID)
        //{
        //    String sProjectPath = (new File("test-reports/") + getAbsolutePath().concat(File.separator).concat(BaseTest.reportFolder).concat(File.separator).concat(Project).concat(File.separator));
        //    DateFormat dateFormat = new SimpleDateFormat("_yyyy_MM_dd_HH_mm_ss");
        //    //  get current date time with Date()
        //    Date date = new Date();
        //    File scrFile = ((TakesScreenshot)(driver)).getScreenshotAs(OutputType.FILE);
        //    String fileScrShot = (sProjectPath.concat(ClassNames)
        //                + (File.separator
        //                + (TCsID
        //                + (File.separator
        //                + (Result + ("_"
        //                + (dateFormat.format(date).toString() + ".png")))))));
        //    CommonElements.sScreenShot_Path = (Project.concat(File.separator).concat(ClassNames)
        //                + (File.separator
        //                + (TCsID
        //                + (File.separator
        //                + (Result + ("_"
        //                + (dateFormat.format(date).toString() + ".png")))))));
        //    try
        //    {
        //        FileUtils.copyFile(scrFile, new File(fileScrShot));
        //    }
        //    catch (IOException ex)
        //    {
        //        //  TODO Auto-generated catch block
        //        System.err.println(e);
        //    }

        //    this.addLog(("Captured a screenshot to: " + fileScrShot));
        //    return fileScrShot;
        //}

        //public void selectBeecowDropdown(String name, String value)
        //{
        //    String locatorDrpBtn = String.format("xpath::.//div[contains(@class,\'%s\')]/button", name);
        //    String locatorDrpOption = String.format("xpath::.//div[contains(@class,\'%s\')]//a[text()=\'%s\']", name, value);
        //    try
        //    {
        //        this.FindElement(locatorDrpBtn).click();
        //        this.waitForElementClickable(locatorDrpOption);
        //        this.hover(locatorDrpOption);
        //        Thread.sleep(500);
        //        this.FindElement(locatorDrpOption).click();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("\n[######### SELECT FAILED =========> The dropdown ["
        //                        + (name + ("] locator with option = " + ("["
        //                        + (value + ("] NOT EXIST or NOT CLICKABLE\n] " + ex.getMessage())))))));
        //    }

        //}

        //public void selectRandomDropDownList(String locatorDrpBtn, String locatorDrpOption)
        //{
        //    String nameCate = "";
        //    try
        //    {
        //        //  click element at dropdown list to show all items
        //        IWebElement drp = this.FindElement(locatorDrpBtn);
        //        drp.click();
        //        System.out.println("-----Click button to show dropdown successfully-----");
        //        //  get random item from dropdown list
        //        List<IWebElement> els = this.FindElements(locatorDrpOption);
        //        int cate = this.getRandomIndex((els.size() - 1));
        //        System.out.println(("------Total of list dropdown----" + els.size()));
        //        System.out.println(("------Value is selected in position----" + cate));
        //        els.get(cate).click();
        //        System.out.println(("------Value of dropdown will be selected----" + nameCate));
        //        //  click item is selected
        //        //  waitForElementClickable(locatorDrpOption);
        //        //  hover(locatorDrpOption);
        //        System.out.println(("Select main categories---" + nameCate));
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("\n[######### SELECT FAILED =========> The dropdown ["
        //                        + (nameCate + ("] locator with option = ["
        //                        + (nameCate + ("] NOT EXIST or NOT CLICKABLE\n] " + ex.getMessage()))))));
        //    }

        //}

        //public void selectRandomDropDownListByValue(String locatorDrpBtn, String locatorDrpOption)
        //{
        //    String nameCate = "";
        //    try
        //    {
        //        this.FindElement(locatorDrpBtn).click();
        //        List<IWebElement> els = this.FindElements(locatorDrpOption);
        //        int cate = this.getRandomIndex((els.size() - 1));
        //        nameCate = els.get(cate).getText();
        //        foreach (IWebElement element in els)
        //        {
        //            if (element.getText().equalsIgnoreCase(nameCate))
        //            {
        //                element.click();
        //                break;
        //            }

        //        }

        //        System.out.println(("Select main categories " + nameCate));
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("\n[######### SELECT FAILED =========> The dropdown ["
        //                        + (nameCate + ("] locator with option = ["
        //                        + (nameCate + ("] NOT EXIST or NOT CLICKABLE\n] " + ex.getMessage()))))));
        //    }

        //}

        //public void selectDropDownListByValue(String locatorDrpBtn, String locatorDrpOption)
        //{
        //    try
        //    {
        //        Thread.sleep(2000);
        //        this.FindElement(locatorDrpBtn).click();
        //        this.FindElement(locatorDrpOption).click();
        //    }
        //    catch (NoSuchElementException)
        //    {
        //    }

        //    InterruptedException exlement;
        //    Result.checkFail(("Class Helper | Method selectDropDownListByValue | Exception desc : " + e.getMessage()));
        //}



        //public String selectRandomOptionVisible(String locator)
        //{
        //    try
        //    {
        //        List<IWebElement> els = this.FindElements(locator);
        //        int cate = this.getRandomIndex((els.size() - 1));
        //        String namecate = els.get(cate).getText();
        //        foreach (IWebElement element in els)
        //        {
        //            element.getText().equalsIgnoreCase(namecate);
        //            element.click();
        //            break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method selectRandomOptionVisible | Exception desc : " + e.getMessage()));
        //    }

        //    return locator;
        //}

        //public void hover(String locator)
        //{
        //    Actions action = new Actions(driver);
        //    IWebElement element = this.FindElement(locator);
        //    try
        //    {
        //        action.moveToElement(e).build().perform();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        this.addLog(("\n[######### HOVER ELEMENT FAILED =========> The element NOT EXIST or NOT CLICKABLE\n] " + ex.getMessage()));
        //    }

        //}

        //public void focusElementFieldAndInputField(String locator, String data)
        //{
        //    try
        //    {
        //        IWebElement element = this.FindElement(locator);
        //        element.equals(driver.switchTo().activeElement());
        //        element.sendKeys(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.addLog(("\n [##### FOCUS ELEMENT FAILED =======> The element NOT EXIST or NOT CLICKABLE\n]" + ex.getMessage()));
        //    }

        //}

        //public Boolean isBeecowDropdownPresent(String name)
        //{
        //    Boolean isPresent = Boolean.FALSelement;
        //    try
        //    {
        //        isPresent = (this.FindElements(String.format("xpath::.//div[contains(@class,\'%s\')]/button", name)).size() > 0);
        //        return isPresent;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        return isPresent;
        //    }

        //}

        //public void click_BeecowDropdownOptionInvisible(String locator)
        //{
        //    IWebElement element = this.FindElement(locator);
        //    try
        //    {
        //        this.hover(locator);
        //        JavascriptExecutor js = ((JavascriptExecutor)(driver));
        //        js.executeScript("arguments[0].focus();", element);
        //        js.executeScript("arguments[0].click();", element);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method click_BeecowDropdownOptionInvisible | Exception desc : " + ex.getMessage()));
        //    }

        //}

        //public void switchToPopUp(WebDriver driver)
        //{
        //    String subWindowHandler = null;
        //    Set<String> handles = driver.getWindowHandles();
        //    //  get all window
        //    //  handles
        //    Iterator<String> iterator = handles.iterator();
        //    while (iterator.hasNext())
        //    {
        //        subWindowHandler = iterator.next();
        //    }

        //    driver.switchTo().window(subWindowHandler);
        //}

        //public void switchtoWindowBytitle(String title)
        //{
        //    Set<String> allWindows = driver.getWindowHandles();
        //    foreach (String runWindows in allWindows)
        //    {
        //        driver.switchTo().window(runWindows);
        //        String currentWin = driver.getTitle();
        //        if (currentWin.equals(title))
        //        {
        //            break;
        //        }

        //    }

        //}

        //public void switchToChildWindowByID(String parent)
        //{
        //    Set<String> allWindows = driver.getWindowHandles();
        //    foreach (String runWindow in allWindows)
        //    {
        //        if (!runWindow.equals(parent))
        //        {
        //            driver.switchTo().window(runWindow);
        //            break;
        //        }

        //    }

        //}

        //public void closeOtherWindows(String parentPage)
        //{
        //    Set<String> set = driver.getWindowHandles();
        //    set.remove(parentPage);
        //    assert set.sizelement;
        //    1;
        //    driver.switchTo().window(((String)(set.toArray()[0])));
        //    driver.close();
        //    driver.switchTo().window(parentPage);
        //}

        //public void closeAllWithoutParentWindows(String parentWindow)
        //{
        //    Set<String> allWindows = driver.getWindowHandles();
        //    foreach (String runWindows in allWindows)
        //    {
        //        if (!runWindows.equals(parentWindow))
        //        {
        //            driver.switchTo().window(runWindows);
        //            driver.close();
        //        }

        //    }

        //    driver.switchTo().window(parentWindow);
        //}

        //public void upload_File(String locator, String fileName)
        //{
        //    String path = System.getProperty("user.dir");
        //    try
        //    {
        //        IWebElement element = this.FindElement(locator);
        //        element.sendKeys(path.concat(PATH_FILES).concat(File.separator).concat(fileName));
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method upload_File | LOCATOR UPLOAD must be <input and [@type=file]> \nException desc :" +
        //            " " + ex.getMessage()));
        //    }

        //}

        //public String get_CurrentUrl()
        //{
        //    String currentUrl = "";
        //    try
        //    {
        //        currentUrl = driver.getCurrentUrl();
        //        return currentUrl;
        //    }
        //    catch (Exception ex)
        //    {
        //        Result.checkFail(("Class Helper | Method get_CurrentUrl | Exception desc : " + ex.getMessage()));
        //    }

        //    return currentUrl;
        //}

        //public String getDataExpectedResult(String data, String verifyTag)
        //{
        //    data = data.substring((data.indexOf(("<"
        //                        + (verifyTag + ">")))
        //                    + (verifyTag.length() + 2)), data.indexOf(("</"
        //                        + (verifyTag + ">"))));
        //    System.out.println(("Data verify is: "
        //                    + (data + "\n==============")));
        //    return data;
        //}

        //public String convertArrayToString(String...arrStr Unknown)
        //{
        //    return Stream.of(arrStr).collect(Collectors.joining(",", "", ""));
        //}

        //public String convertListToString(List<String> stringList)
        //{
        //    return String.join(",", stringList);
        //}

        //public int formatPriceStringToInt(String price)
        //{
        //    String str = price.replaceAll("[^0-9]", "");
        //    return Integer.parseInt(str);
        //}

        //public List<String> removeDuplicate(String...arr Unknown)
        //{
        //    List<String> listWithDuplicates = new ArrayList();
        //    listWithDuplicates.addAll(Arrays.asList(arr));
        //    List<String> listWithoutDuplicates = listWithDuplicates.stream().distinct().collect(Collectors.toList());
        //    return listWithoutDuplicates;
        //}


    }
}