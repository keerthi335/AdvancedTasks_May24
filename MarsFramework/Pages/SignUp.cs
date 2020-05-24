using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignUp
    {
        internal void register()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignUp");

            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            //Identify and Click on Join button
            IWebElement Join = GlobalDefinitions.driver.FindElement(By.XPath("//button[text()='Join']"));
            Join.Click();

            //Enter FirstName
            IWebElement FirstName = GlobalDefinitions.driver.FindElement(By.Name("firstName"));
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //Enter LastName
            IWebElement LastName = GlobalDefinitions.driver.FindElement(By.Name("lastName"));
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Enter Email
            IWebElement Email = GlobalDefinitions.driver.FindElement(By.Name("email"));
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Email"));

            //Enter Password
            IWebElement Password = GlobalDefinitions.driver.FindElement(By.Name("password"));
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Enter Password again to confirm
            IWebElement ConfirmPassword = GlobalDefinitions.driver.FindElement(By.Name("confirmPassword"));
            ConfirmPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ConfirmPswd"));

            //Click on Checkbox
            IWebElement Checkbox = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='terms']"));
            Checkbox.Click();

            //Click on join button to Sign Up
            IWebElement JoinBtn = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='submit-btn']"));
            JoinBtn.Click();
        }
    }
}
