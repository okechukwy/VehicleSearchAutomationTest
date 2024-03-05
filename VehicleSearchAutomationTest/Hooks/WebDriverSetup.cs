using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VehicleSearchAutomationTest.Configuration;

namespace VehicleSearchAutomationTest.Support
{
   
    [Binding]
    public class WebDriverSetup
    {
        static WebDriverSupport? _driverSetup;

        [BeforeTestRun]
        public static void InstantiateDriverSetup(IObjectContainer objectContainer)
        {
            _driverSetup = new WebDriverSupport(objectContainer);
        }

        [BeforeScenario()]
        public static void ChromeDriverInitialiserBeforeScenario()
        {
           
            var options = new ChromeOptions();
            options.AddArguments("start-maximized");
            #pragma warning disable CS8602
            _driverSetup.InitializeWebDriver(BrowserType.Chrome, options);
        }

        [AfterScenario()]
        public static void ScenarioTeardown() => _driverSetup.ScenarioTeardown();



        [AfterFeature()]
        public static void FeatureTeardown() => _driverSetup.ScenarioTeardown();
        


    }
}
