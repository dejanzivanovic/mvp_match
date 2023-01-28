using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPMatch_UI_Automatization.Pages
{
    class BasicFormPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public BasicFormPage(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(_driver, this);
        }


        //locators
        [FindsBy(How = How.CssSelector, Using = "div[class='card-header'] h3")]
        private IWebElement titleElement;

        [FindsBy(How = How.Id, Using = "exp")]
        private IWebElement experianceElement;

        [FindsBy(How = How.Id, Using = "exp_help")]
        private IWebElement experianceResultElement;

        [FindsBy(How = How.Id, Using = "check_java")]
        private IWebElement checkJavaElement;

        [FindsBy(How = How.Id, Using = "check_python")]
        private IWebElement checkPythonElement;

        [FindsBy(How = How.Id, Using = "check_javascript")]
        private IWebElement checkJavaScriptElement;

        [FindsBy(How = How.Id, Using = "check_validate")]
        private IWebElement checkValidateElement;

        [FindsBy(How = How.Id, Using = "rad_selenium")]
        private IWebElement radSeleniumElement;

        [FindsBy(How = How.Id, Using = "rad_protractor")]
        private IWebElement radProtractorElement;

        [FindsBy(How = How.Id, Using = "rad_validate")]
        private IWebElement radValidateElement;

        [FindsBy(How = How.Id, Using = "select_tool")]
        private IWebElement primarySkillElement;

        [FindsBy(How = How.Id, Using = "select_tool_validate")]
        private IWebElement validatePrimarySkillElement;

        [FindsBy(How = How.Id, Using = "select_lang")]
        private IWebElement chooseLanguageElement;

        [FindsBy(How = How.Id, Using = "select_lang_validate")]
        private IWebElement chooseLanguageValidationElement;

        [FindsBy(How = How.Id, Using = "notes")]
        private IWebElement notesElement;

        [FindsBy(How = How.Id, Using = "area_notes_validate")]
        private IWebElement notesValidationElement;

        [FindsBy(How = How.Id, Using = "common_sense")]
        private IWebElement mandatorySkillElement;

        [FindsBy(How = How.CssSelector, Using = "label[class='custom-control-label']")]
        private IWebElement speaksGermanElement;

        [FindsBy(How = How.Id, Using = "german_validate")]
        private IWebElement speaksGermanValidateElement;

        [FindsBy(How = How.Id, Using = "fluency")]
        private IWebElement sliderElement;

        [FindsBy(How = How.Id, Using = "fluency_validate")]
        private IWebElement sliderValidationElement;

        [FindsBy(How = How.Id, Using = "upload_cv")]
        private IWebElement profilePictureElement;

        [FindsBy(How = How.Id, Using = "validate_cv")]
        private IWebElement profilePictureValidateElement;


        [FindsBy(How = How.Id, Using = "upload_files")]
        private IWebElement uploadFilesElement;

        [FindsBy(How = How.Id, Using = "validate_files")]
        private IWebElement validateUploadFilesElement;

        [FindsBy(How = How.Id, Using = "salary")]
        private IWebElement currentSalaryElement;

        [FindsBy(How = How.Id, Using = "validationCustom03")]
        private IWebElement validationCityElement;

        [FindsBy(How = How.Id, Using = "invalid_city")]
        private IWebElement validationInvalidCityElement;

        [FindsBy(How = How.Id, Using = "validationCustom04")]
        private IWebElement validationStateElement;

        [FindsBy(How = How.Id, Using = "invalid_state")]
        private IWebElement validationInvalidStateElement;

        [FindsBy(How = How.Id, Using = "validationCustom05")]
        private IWebElement validationZipElement;

        [FindsBy(How = How.Id, Using = "invalid_zip")]
        private IWebElement validationInvalidZipElement;

        [FindsBy(How = How.Id, Using = "invalidCheck")]
        private IWebElement validationTOCElement;

        [FindsBy(How = How.Id, Using = "invalid_terms")]
        private IWebElement validationInvalidTOCElement;

        [FindsBy(How = How.CssSelector, Using = "button[type=submit]")]
        private IWebElement submitButtonElement;
    
        [FindsBy(How = How.XPath, Using = "(//input[@aria-describedby='expHelp'])[2]")]
        private IWebElement nonEnglishTextBoxElement;

        [FindsBy(How = How.XPath, Using = "(//input[@aria-describedby='expHelp'])[2]/following-sibling::span[1]")]
        private IWebElement nonEnglishTextBoxVerificationElement;

        [FindsBy(How = How.XPath, Using = "(//div[(@class='form-check form-check-inline')])[6]")]
        private IWebElement nonEnglishCheckBoxElement;

        [FindsBy(How = How.XPath, Using = "(//div[(@class='form-check form-check-inline')])[7]")]
        private IWebElement nonEnglishCheckBox2Element;

        [FindsBy(How = How.XPath, Using = "(//div[(@class='form-check form-check-inline')])[8]")]
        private IWebElement nonEnglishCheckBox3Element;

        [FindsBy(How = How.Id, Using = "check_validate_non_english")]
        private IWebElement checkValidateNonEnglishElement;
       


        public Boolean isPageOpen()
        {
            return titleElement.Text.Equals("Basic Form Controls");
        }

        public void enterYearsOfExperiance(string years)
        {
            experianceElement.SendKeys(years);

        }
        public string experianceResult()
        {
            return experianceResultElement.Text;
        }

        public void languageSelector(string element)
        {
            switch(element)
            {
                case ("Java"):
                    checkJavaElement.Click();
                    break;

                case ("Python"):
                    checkPythonElement.Click();
                    break;

                case ("JavaScript"):
                    checkJavaScriptElement.Click();
                    break;

                default:
                    break;
            }
        }
        public string languageValidate()
        {
            return checkValidateElement.Text;
        }

        public void radSelector(string element)
        {
            switch (element)
            {
                case ("Selenium"):
                    radSeleniumElement.Click();
                    break;

                case ("Protractor"):
                    radProtractorElement.Click();
                    break;

                default:
                    break;
            }
        }
        public string radValidate()
        {
            return radValidateElement.Text;
        }
        public void selectPrimarySkill(string skilltext)
        {
            SelectElement skill = new SelectElement(primarySkillElement);
            skill.SelectByText(skilltext);
        }
        public string validatePrimarySkill()
        {
            return validatePrimarySkillElement.Text;
        }

        public void chooseLanguage(string languagetext)
        {
            SelectElement language = new SelectElement(chooseLanguageElement);
            language.SelectByText(languagetext);
            
        }
        public string chooseLanguageValidation()
        {
            return chooseLanguageValidationElement.Text;
        }

        public void enterNotes(string notestext)
        {
            notesElement.Clear();
            notesElement.SendKeys(notestext);
        }

        public string notesValidation()
        {
            return notesValidationElement.Text;
        }

        public string mandatorySkillCheck()
        {
            Assert.True(mandatorySkillElement.GetAttribute("readOnly").Equals("true"), "Element is ReadOnly");
            return mandatorySkillElement.GetAttribute("placeholder").ToString();
        }
        public void speaksGerman()
        {
            speaksGermanElement.Click();
           
        }
        public string speaksGermanValidate()
        {
            return speaksGermanValidateElement.Text;
        }

        public void setSlider(int x)
        {
            int width = sliderElement.Size.Width;
            Actions act = new Actions(_driver);
            act.MoveToElement(sliderElement, ((width * x) / 100), 0).Click();
            act.Build().Perform();
        }

        public string sliderValidation()
        {
            return sliderValidationElement.Text;
        }

        public void uploadPicture()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string picture = projectDirectory + "\\Picture\\profile.png";

            profilePictureElement.SendKeys(picture);

        }

        public string verifyPictureUplad()
        {
            return profilePictureValidateElement.Text;

        }

        public void uploadFiles()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string picture = projectDirectory + "\\Picture\\profile.png";
            string picture2 = projectDirectory + "\\Picture\\bug.png";

            uploadFilesElement.SendKeys(picture);
            uploadFilesElement.SendKeys(picture2);

        }

        public string verifyUploadedFiles()
        {
            return validateUploadFilesElement.Text;
        }

        public string currentSalary()
        {
            Assert.True(currentSalaryElement.Enabled.Equals(false));
            Assert.True(currentSalaryElement.GetAttribute("disabled").Equals("true"), "Element is disabled");
            return currentSalaryElement.GetAttribute("placeholder").ToString();
        }

        public string negativeValidationCase()
        {
            validationCityElement.Click();
            validationCityElement.Clear();
            validationCityElement.SendKeys(Keys.Enter);
            return validationInvalidCityElement.Text + " " + validationInvalidStateElement.Text + " " + validationInvalidZipElement.Text + " " + validationInvalidTOCElement.Text;
        }

        public void positiveVladidationCase()
        {
            validationCityElement.SendKeys("Belgrade");
            validationStateElement.SendKeys("SRB");
            validationZipElement.SendKeys("11000");
            validationTOCElement.Click();
            submitButtonElement.Click();



        }

        public void nonEnglishLabelsAndLocators()
        {
            nonEnglishTextBoxElement.Clear();
            nonEnglishTextBoxElement.SendKeys("Test");
            nonEnglishCheckBoxElement.Click();
            nonEnglishCheckBox2Element.Click();
            nonEnglishCheckBox3Element.Click();

        }

        public string nonEnglishLablesVerificationText()
        {
            return nonEnglishTextBoxVerificationElement.Text;
        }
        public string checkValidateNonEnglish()
        {
            return checkValidateNonEnglishElement.Text;
        }
    }
}
