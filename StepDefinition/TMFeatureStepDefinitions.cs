using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using TurnUpPortal.Pages;
using TurnUpPortal.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace TurnUpPortal.StepDefinition
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        
        [Given("I logged into Turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();
            //options.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            driver = new ChromeDriver(options);
            //Implicit Wait
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //User has logged in successfully
            loginPageObj.VerifyUserInHomePage(driver);
        }

        [When("I navigate to Time and Material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            //Home page object intialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
        }

        [When("I create a time record")]
        public void WhenICreateATimeRecord()
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.CreateTimeRecord(driver);
        }

        [Then("the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {
            TMPage tMPageObj = new TMPage();

            string newCode = tMPageObj.GetCode(driver);
            string newDescription = tMPageObj.GetDescription(driver);
            string newPrice = tMPageObj.GetPrice(driver);
            Assert.That(newCode == "ABC", "Actual Code and expected Code do not match.");
            Assert.That(newDescription == "ABCDescription", "Actual Description and expected Description do not match.");
            Assert.That(newPrice == "$20.00", "Actual Price and expected Price do not match.");
        }
        [When("I update the {string} on an existing Time record")]
        public void WhenIUpdateTheOnAnExistingTimeRecord(string code)
        {
            TMPage tMPageObj = new TMPage();
            tMPageObj.EditTimeRecord(driver, code);
        }
        [Then("the record should have the updated {string}")]
        public void ThenTheRecordShouldHaveTheUpdated(string code)
        {
            TMPage tMPageObj = new TMPage();

            string editedDescription = tMPageObj.GetEditedDescription(driver);

            Assert.That(editedDescription == code, "Expected Description does not match with actual Description");
        }



    }
}
