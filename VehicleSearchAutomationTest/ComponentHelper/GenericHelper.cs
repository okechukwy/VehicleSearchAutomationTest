using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VehicleSearchAutomationTest.Settings;

namespace VehicleSearchAutomationTest.ComponentHelper
{
    public class GenericHelper
    {
        protected readonly IWebDriver? _driver;
        public bool IsElemetPresent(By locator)
        {
            try
            {
                return _driver?.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
