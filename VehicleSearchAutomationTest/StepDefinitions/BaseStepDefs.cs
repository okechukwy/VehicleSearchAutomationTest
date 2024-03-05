using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using VehicleSearchAutomationTest.Pages;

namespace VehicleSearchAutomationTest.StepDefinitions
{
    [Binding]
    public class BaseStepDefs<P> where P : BasePage
    {
        protected P? _Page { get; set; }

        protected IWebDriver? driver { get; set; }
    }
}
