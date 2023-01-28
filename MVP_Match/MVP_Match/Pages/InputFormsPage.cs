using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

using SeleniumExtras.PageObjects;

namespace MVPMatch_UI_Automatization.Pages
{
    class InputFormsPage {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public InputFormsPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }


        //locators
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'registration_form')]/h2")]
        private IWebElement titleElement;

        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement firstnameElement;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Last Name')]/following-sibling::input[1]")]
        private IWebElement lastnameElement;

        [FindsBy(How = How.ClassName, Using = "radio_wrap")]
        private IList<IWebElement> maritalStatusElements;

        [FindsBy(How = How.Name, Using = "hobby")]
        private IList<IWebElement> hobbyElements;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Country')]/following-sibling::select")]
        private IWebElement countryElement;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Date of Birth')]/following-sibling::div[1]/select")]
        private IWebElement monthDOBElement;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Date of Birth')]/following-sibling::div[2]/select")]
        private IWebElement dayDOBElement;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Date of Birth')]/following-sibling::div[3]/select")]
        private IWebElement yearDOBElement;

        [FindsBy(How = How.Name, Using = "phone")]
        private IWebElement phoneElement;

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement usernameElement;

        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement emailElement;

        [FindsBy(How = How.XPath, Using = "//input[@type='file']")]
        private IWebElement profilePictureElement;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'About Yourself')]/following-sibling::textarea")]
        private IWebElement aboutYorselfElement;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordElement;

        [FindsBy(How = How.Name, Using = "c_password")]
        private IWebElement confirmpasswordElement;

        [FindsBy(How = How.CssSelector, Using = "input[type=submit]")]
        private IWebElement submitButtonElement;

        public Boolean isPageOpen()
        {
            return titleElement.Text.Equals("Registration Form");
        }
        public void fillFirstandLastName(string name, string lastname) { 
              
        
            firstnameElement.Clear();
            firstnameElement.SendKeys(name);

            lastnameElement.Clear();
            lastnameElement.SendKeys(lastname);

        }
        public void enterMaritalStatus(string m_status) {
            foreach (IWebElement element in maritalStatusElements)
            {

                IWebElement ms = element.FindElement(By.XPath($"//label[contains(text(),'{m_status}')]"));
                ms.Click();

            }
        }
        public void enterHobby(string hobby) {
                foreach (IWebElement element in hobbyElements)
                {
                    IWebElement ho = element.FindElement(By.XPath($"//label[contains(text(),'{hobby}')]"));
                    ho.Click();
                }
            }
        public void selectCountry(string country) {

            SelectElement count = new SelectElement(countryElement);
            count.SelectByText(country);

        }
        public void enterDOB(string dayDob, string monthDob, string yearDob) {

            SelectElement day = new SelectElement(dayDOBElement);
            day.SelectByText(dayDob);

            SelectElement month = new SelectElement(monthDOBElement);
            month.SelectByText(monthDob);


            SelectElement year = new SelectElement(yearDOBElement);
            year.SelectByText(yearDob);

        }
        public void enterPhone(string phone) {

            phoneElement.Clear();
            phoneElement.SendKeys(phone);

        }
        public void enterUsername(string username) {

            usernameElement.Clear();
            usernameElement.SendKeys(username);

        }
        public void enterEmail(string email) {

            emailElement.Clear();
            emailElement.SendKeys(email);

        }
        public void enterAboutMe(string about_me) {

            aboutYorselfElement.Clear();
            aboutYorselfElement.SendKeys(about_me);

        }

        public void enterPassword(string password)
        {

            passwordElement.Clear();
            passwordElement.SendKeys(password);

        }
        public void confirmPassword(string password) { 

            confirmpasswordElement.Clear();
            confirmpasswordElement.SendKeys(password);

        
        }

        public void uploadPicture()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string picture = projectDirectory + "\\Picture\\profile.png";

            profilePictureElement.SendKeys(picture);

        }
        public void clickSubmit()
        {
            submitButtonElement.Submit();
        }


    }
}
