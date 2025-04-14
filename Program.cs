using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open chrome browser
        IWebDriver driver = new ChromeDriver();
        //Launch Trunup portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/"); 
        driver.Manage().Window.Maximize();
        Thread.Sleep(1000);
        //Identify username textbox and enter valid user name
        IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
        usernameTextbox.SendKeys("hari");

        // Identify password textbox and enter valid password
        IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
        passwordTextbox.SendKeys("345345");
        // Identify login button and click on it
        IWebElement loginButton = driver.FindElement(By.XPath(" //*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginButton.Click();
        Thread.Sleep(2000);//thread means stop
        // check if user has logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath(" //*[@id=\"logoutForm\"]/ul/li/a"));

        if (hellohari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed");
        }
        // create a Time record
        //  Navigate to Time and Material Page
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
        administrationTab.Click();
        
        
        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();
        
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();
        Thread.Sleep(1000);
        
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();  

        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        codeTextbox.SendKeys("ABC");
        
        IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
        descriptionTextbox.SendKeys("ABCDescription");
        Thread.Sleep(1000);

        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();
        
        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("20");
        
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(1000);
        
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();

      

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (newCode.Text == "ABC")
        { 
            Console.WriteLine("Time record created successfully!"); 
        }
        else
        {
            Console.WriteLine("New time record has not been created!");
        }

        // Create an Edit Record 
        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[4]/td[5]/a[1]"));
        editButton.Click();
        /*IWebElement global_descriptionTextbox = driver.FindElement(By.Id("Description"));
        global_descriptionTextbox.Clear();
        global_descriptionTextbox.SendKeys("cbaDescription");*/

        IWebElement global_typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        global_typeCodeDropdown.Click();

        /*IWebElement typeCodeList = driver.FindElement(By.Id("TypeCode-list"));
        typeCodeList.Click();*/
        




        /*IWebElement global_timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        global_timeOption.Click();*/


        /*IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]"));
        materialOption.Click();*/
        IWebElement global_saveButton = driver.FindElement(By.Id("SaveButton"));
        global_saveButton.Click();
        Thread.Sleep(1000);

        // Create a Delete Record
        /*IWebElement global_goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        global_goToLastPageButton.Click();
        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[3]/td[5]/a[2]"));
        deleteButton.Click();
        driver.SwitchTo().Alert().Accept();*/
    }
}

