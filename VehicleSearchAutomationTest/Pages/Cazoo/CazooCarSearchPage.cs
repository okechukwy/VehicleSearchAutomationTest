using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using VehicleSearchAutomationTest.ComponentHelper;
using VehicleSearchAutomationTest.ExcelReader;

namespace VehicleSearchAutomationTest.Pages
{
    public class CazooCarSearchPage : BasePage
    {
        private TextBoxHelper textBoxHelper;
        private IWebDriver driver;
        private CarValuation carValuation;
        public static By AllCookies = By.XPath("//span[contains(text(),'Accept All')]");
        public static By SearchField = By.CssSelector("#vrm");
        public static By SubmitButton = By.XPath("//span[contains(text(),'Get started')]");
        public const string Title = "Value my car - how much is my car worth? | Cazoo";

        public CazooCarSearchPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
            carValuation = new CarValuation();
        }

        public void AcceptCookies()
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, AllCookies, 5);
            driver.FindElement(AllCookies).Click();
           

        }

        public void EnterVehicleRegistration(string registration)
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, SearchField, 5);
            driver.FindElement(SearchField).SendKeys(registration);

        }

        public void SearchVehicleDetails()
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, SubmitButton, 5);
            driver.FindElement(SubmitButton).Click ();  

        }

        public void NavigateToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }


    }
}
