using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using SeleniumExtras.PageObjects;

namespace MVPMatch_UI_Automatization.Pages
{
    class AlertFormPage {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public AlertFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }


        //locators
        [FindsBy(How = How.ClassName, Using = "heading")]
        private IWebElement titleElement;

        [FindsBy(How = How.CssSelector, Using = "div[id='example-1-tab-1'] iframe")]
        private IWebElement simpleAlertframeElement;

        [FindsBy(How = How.CssSelector, Using = "div[id='example-1-tab-2'] iframe")]
        private IWebElement inputAlertframeElement;

        [FindsBy(How = How.CssSelector, Using = "body > button")]
        private IWebElement alertButtonElement;

        [FindsBy(How = How.PartialLinkText, Using = "INPUT ALERT")]
        private IWebElement inputButtonNavigationElement;

        [FindsBy(How = How.Id, Using = "demo")]
        private IWebElement messageElement;





        public Boolean isPageOpen()
        {
            return titleElement.Text.Equals("Alert");
        }
        
        public void clickOnAlertButton()
        {
            _driver.SwitchTo().Frame(simpleAlertframeElement);
            
            alertButtonElement.Click();

        }
        public void clickOnInputAlertButton()
        {
            _driver.SwitchTo().Frame(inputAlertframeElement);

            alertButtonElement.Click();

        }
        public string simpleAlertText()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            return alert.Text;
        }
        public void closeSimpleAlert()
        {
            IAlert alert = _driver.SwitchTo().Alert();
            alert.Accept();

        }

        public void clickOnInputNavigationButton()
        {
            _driver.SwitchTo().DefaultContent();
            inputButtonNavigationElement.Click();

        }
        public void enterInputAlertText(String input)
        {
            
            IAlert alert = _driver.SwitchTo().Alert();
            alert.SendKeys(input);
            alert.Accept();

        }

        public string alertMessage()
        {
            return messageElement.Text;
        }
    }
}
