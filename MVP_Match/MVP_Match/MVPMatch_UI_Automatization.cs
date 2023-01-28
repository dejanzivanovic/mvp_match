using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;
using MVPMatch_UI_Automatization.Pages;

namespace MVPMatch_UI_Automatization
{
    [TestFixture]
    public class MVPMatchUIAutomatization
    {
        public IWebDriver _driver;
        public IConfiguration _config;
        public WebDriverWait _wait;
       
        string _registrationFormURL= "https://www.way2automation.com/way2auto_jquery/registration.php#load_box";
        string _alertsFormURL = "https://www.way2automation.com/way2auto_jquery/alert.php#load_box";
        string _basicFormURL = "https://dineshvelhal.github.io/testautomation-playground/forms.html";

    

        [SetUp]
        public void setup()
        {
            
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            _driver.Manage().Window.Maximize();
        }
        


        [Test,Order(1)]
        //[Ignore("Ignoring")]
        public void registrationFormTest()
        {

         
            _driver.Navigate().GoToUrl(_registrationFormURL);
           
            var inputFormPage = new InputFormsPage(_driver);
            Assert.IsTrue(inputFormPage.isPageOpen());

            inputFormPage.fillFirstandLastName("Dejan", "Zivanovic");
            inputFormPage.enterMaritalStatus("Married");
            inputFormPage.enterHobby("Reading");
            inputFormPage.selectCountry("India");
            inputFormPage.enterDOB("1", "1", "2014");
            inputFormPage.enterPhone("+381652283432");
            inputFormPage.enterUsername("dejan");
            inputFormPage.enterEmail("dejan.test@test.com");
            inputFormPage.enterAboutMe("I live nature, kids and swimming");
            inputFormPage.enterPassword("password");
            inputFormPage.confirmPassword("password");
            inputFormPage.uploadPicture();
            inputFormPage.clickSubmit();
           

        }

        [Test, Order(2)]
        //[Ignore("Ignoring")]

        public void SimpleAlertTest()
        {
            _driver.Navigate().GoToUrl(_alertsFormURL);
            AlertFormPage AlertPage=new AlertFormPage(_driver);
            Assert.IsTrue(AlertPage.isPageOpen());

            AlertPage.clickOnAlertButton();
            Assert.That(AlertPage.simpleAlertText(),Is.EqualTo("I am an alert box!"));

            AlertPage.closeSimpleAlert();

            AlertPage.clickOnInputNavigationButton();
            AlertPage.clickOnInputAlertButton();
            AlertPage.enterInputAlertText("Dejan");

            Assert.That(AlertPage.alertMessage(), Is.EqualTo("Hello Dejan! How are you today?"));
        }

        [Test, Order(3)]
        //[Ignore("Ignoring")]
        public void BasicFormTest()
        {
            _driver.Navigate().GoToUrl(_basicFormURL);
            BasicFormPage basicFormPage = new BasicFormPage(_driver);
            Assert.IsTrue(basicFormPage.isPageOpen());

            basicFormPage.enterYearsOfExperiance("10");
            Assert.That(basicFormPage.experianceResult(), Is.EqualTo("10"));

            basicFormPage.languageSelector("Java");
            Assert.That(basicFormPage.languageValidate(), Is.EqualTo("JAVA"));

            basicFormPage.languageSelector("Python");
            Assert.That(basicFormPage.languageValidate(), Does.Contain("JAVA PYTHON"));

            basicFormPage.languageSelector("JavaScript");
            Assert.That(basicFormPage.languageValidate(), Does.Contain("JAVA PYTHON JAVASCRIPT"));

            basicFormPage.radSelector("Selenium");
            Assert.That(basicFormPage.radValidate(), Is.EqualTo("SELENIUM"));

            basicFormPage.radSelector("Protractor");
            Assert.That(basicFormPage.radValidate(), Is.EqualTo("PROTRACTOR"));

            basicFormPage.selectPrimarySkill("Cypress");
            Assert.That(basicFormPage.validatePrimarySkill(), Does.Contain("cyp"));

            basicFormPage.selectPrimarySkill("Selenium");
            Assert.That(basicFormPage.validatePrimarySkill(), Does.Contain("sel"));

            basicFormPage.selectPrimarySkill("Protractor");
            Assert.That(basicFormPage.validatePrimarySkill(), Does.Contain("pro"));

            basicFormPage.chooseLanguage("Java");
            Assert.That(basicFormPage.chooseLanguageValidation(), Does.Contain("java"));

            basicFormPage.chooseLanguage("Python");
            Assert.That(basicFormPage.chooseLanguageValidation(), Does.Contain("python"));

            basicFormPage.chooseLanguage("JavaScript");
            Assert.That(basicFormPage.chooseLanguageValidation(), Does.Contain("javascript"));

            basicFormPage.chooseLanguage("TypeScript");
            Assert.That(basicFormPage.chooseLanguageValidation(), Does.Contain("typescript"));

            basicFormPage.enterNotes("MVP Match around the world!");
            Assert.That(basicFormPage.notesValidation(), Does.Contain("MVP Match around the world!"));

            Assert.That(basicFormPage.mandatorySkillCheck(), Does.Contain("Common Sense"));
           

            basicFormPage.speaksGerman();
            Assert.That(basicFormPage.speaksGermanValidate(), Does.Contain("true"));

            basicFormPage.speaksGerman();
            Assert.That(basicFormPage.speaksGermanValidate(), Does.Contain("false"));



            basicFormPage.setSlider(10);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("3"));

            basicFormPage.setSlider(20);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("4"));

            basicFormPage.setSlider(40);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("5"));


            basicFormPage.setSlider(-40);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("0"));

            basicFormPage.setSlider(-30);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("1"));

            basicFormPage.setSlider(-10);
            Assert.That(basicFormPage.sliderValidation(), Does.Contain("2"));

            basicFormPage.uploadPicture();
            Assert.That(basicFormPage.verifyPictureUplad(), Does.Contain("profile.png"));

            basicFormPage.uploadFiles();
            Assert.That(basicFormPage.verifyUploadedFiles(), Does.Contain("profile.png"));
            Assert.That(basicFormPage.verifyUploadedFiles(), Does.Contain("bug.png"));


            Assert.That(basicFormPage.currentSalary(), Does.Contain("You should not provide this"));

            
            Assert.That(basicFormPage.negativeValidationCase(), Does.Contain("Please provide a valid city."));
            Assert.That(basicFormPage.negativeValidationCase(), Does.Contain("Please provide a valid state."));
            Assert.That(basicFormPage.negativeValidationCase(), Does.Contain("Please provide a valid zip."));
            Assert.That(basicFormPage.negativeValidationCase(), Does.Contain("You must agree before submitting."));

            basicFormPage.positiveVladidationCase();

            basicFormPage.nonEnglishLabelsAndLocators();
            Assert.That(basicFormPage.nonEnglishLablesVerificationText(), Does.Contain("Test"));
            Assert.That(basicFormPage.checkValidateNonEnglish(), Is.Not.Null);
        }
        [TearDown]
        public void quit()
        {
                  
           _driver.Quit();
        }


      
          
    }
        
}