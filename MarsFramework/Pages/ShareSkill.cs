using AutoItX3Lib;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        
        internal void EnterShareSkill()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            By WaitCondition = By.XPath("//a[text()=\"Share Skill\"]");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            //Identify and Click on "Share Skill" button
            GlobalDefinitions.driver.FindElement(By.XPath("//a[@class='ui basic green button']")).Click();

            By WaitCondition1 = By.XPath("//input[@name='title']");
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition1, 60);

            //Identify and Enter the "Title" field
            IWebElement Title = GlobalDefinitions.driver.FindElement(By.XPath("//input[@name='title']"));
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Identify and Enter the "Description" field
            IWebElement Description = GlobalDefinitions.driver.FindElement(By.XPath("//textarea[@name=\"description\"]"));
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Identify and Select the Category
            IWebElement CategoryDropDown = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name=\"categoryId\"]"));
            SelectElement category = new SelectElement(CategoryDropDown);
            category.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Identify and Select the Subcategory
            IWebElement SubCategoryDropDown = GlobalDefinitions.driver.FindElement(By.XPath("//select[@name=\"subcategoryId\"]"));
            SelectElement SubCategory = new SelectElement(SubCategoryDropDown);
            SubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Identify and enter the value for "Add new tag"
            IWebElement Tags = GlobalDefinitions.driver.FindElement(By.XPath("//h3[text()=\"Tags\"]/parent::div/following-sibling::div//input[@placeholder=\"Add new tag\"]"));
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Enter);

            //Identify and Click Service type
            string ServiceType = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            if (ServiceType == "One-off service")
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'One-off')]")).Click();
            else
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Hourly')]")).Click();

            //Identify and Click Location Type
            string LocationType = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");

            if (LocationType == "On-site")
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'On-site')]")).Click();
            else
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Online')]")).Click();

            //Identify and  Enter Calender

            //Identify and  select Skill Trade
            string SkillTrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");

            if (SkillTrade == "Skill-Exchange")
            {
                IWebElement SkillExchange = GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Skill-exchange')]"));
                SkillExchange.Click();

                IWebElement SkillExchange1 = GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
                
                SkillExchange1.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
                SkillExchange1.SendKeys(Keys.Enter);
            }
            else
            {
                 IWebElement Credit = GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Credit')]"));
                Credit.Click();

                IWebElement CreditAmount = GlobalDefinitions.driver.FindElement(By.XPath("//input[@placeholder='Amount']"));
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CreditAmount"));
            }

            IWebElement Sample = GlobalDefinitions.driver.FindElement(By.XPath("//i[@class='huge plus circle icon padding-25']"));
            Sample.Click();

            Thread.Sleep(1500);

            AutoItX3 AutoIT = new AutoItX3();
            AutoIT.WinActivate("Open");

            Thread.Sleep(1500);

            AutoIT.Send(Base.ImagePath);

            Thread.Sleep(1500);

            AutoIT.Send("{ENTER}");

            //Click on Active field
            string Activefield = GlobalDefinitions.ExcelLib.ReadData(2, "Active");

            if (Activefield == "Active")
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Active')]")).Click();
            else
                GlobalDefinitions.driver.FindElement(By.XPath("//label[contains(text(),'Hidden')]")).Click();

            //Identify and Click on Save button
            GlobalDefinitions.driver.FindElement(By.XPath("//input[@class='ui teal button']")).Click();

        }

        public bool ValidateShareSkill(IWebDriver driver)
        {

            driver.FindElement(By.LinkText("Manage Listings")).Click();
            By WaitCondition = By.XPath("//table[@class='ui striped table']");

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, WaitCondition, 60);

            IWebElement table = driver.FindElement(By.XPath("//table[@class='ui striped table']"));

            IWebElement CategoryInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[2]"));

            if (CategoryInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Category"))
            {
                IWebElement TitleInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[3]"));

                if (TitleInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title"))
                {
                    IWebElement DescriptionInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[4]"));
                    if (DescriptionInTable.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                    {
                        IWebElement ServiceTypeInTable = driver.FindElement(By.XPath("//table[@class='ui striped table']/tbody/tr[1]/td[5]"));
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        
    }
}
