using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace VehicleSearchAutomationTest.Pages.WeBuyAnyCar
{
    public class WeBuyAnyCarSearchResultPage : BasePage
    {
        private IWebDriver driver;

        public static By CarRegistration = By.XPath("//body/div[@id='page-container']//div[1]/div[1]/div[3]/div[1]/vehicle-details[1]/div[3]/div[1]/div[2]"); 
        public static By CarModel = By.XPath("//body/div[@id='page-container']/wbac-app[1]//div[3]/div[1]/vehicle-details[1]/div[3]/div[2]/div[2]/div[2]");
        public static By CarMake = By.XPath("//body/div[@id='page-container']/wbac-app[1]//div[3]/div[1]/vehicle-details[1]/div[3]/div[2]/div[1]/div[2]");
        public WeBuyAnyCarSearchResultPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
    }
}
