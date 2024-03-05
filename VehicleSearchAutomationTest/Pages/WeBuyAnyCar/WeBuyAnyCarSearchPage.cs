using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
 
namespace VehicleSearchAutomationTest.Pages 
{
    public class WeBuyAnyCarSearchPage : BasePage
    {

        private IWebDriver driver;

        public static By AllCookies = By.CssSelector("#onetrust-accept-btn-handler");
        public static By SearchField = By.CssSelector("#vehicleReg");
        public static By MilageField = By.CssSelector("#Mileage");
        public static By GetMyCarValuation = By.CssSelector("#btn-go");

        public WeBuyAnyCarSearchPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }
    }
}
