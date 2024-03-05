using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
