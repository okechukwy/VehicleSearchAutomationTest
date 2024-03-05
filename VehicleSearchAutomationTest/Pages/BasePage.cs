using OpenQA.Selenium;

namespace VehicleSearchAutomationTest.Pages
{
    [Binding]
    public class BasePage
    {
        protected readonly IWebDriver _driver;
       
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
