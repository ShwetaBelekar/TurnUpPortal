using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TurnUpPortal.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open chrome browser
        IWebDriver driver = new ChromeDriver();

        //Implicit Wait
        //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(driver);

        //User has logged in successfully
        loginPageObj.VerifyUserInHomePage(driver);


        //Home page object intialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //TM page object initialization and definition
        TMPage tMPageObj = new TMPage();
        tMPageObj.CreateTimeRecord(driver);

        //Edit Time Record
        tMPageObj.EditTimeRecord(driver);

        //Delete Time Record
        tMPageObj.DeleteTimeRecord(driver);


    }
}

