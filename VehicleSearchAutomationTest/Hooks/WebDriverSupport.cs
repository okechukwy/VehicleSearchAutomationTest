using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using VehicleSearchAutomationTest.Configuration;

namespace VehicleSearchAutomationTest.Support
{
    [Binding]
    public class WebDriverSupport
    {
        private IWebDriver _webdriver;

        private readonly IObjectContainer _objectContainer;

        //private readonly ScreenshotManagement _screenshotManagement;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
           // _screenshotManagement = new ScreenshotManagement();
        }

        public void InitializeWebDriver(BrowserType type, ChromeOptions options = null)
        {
            switch (type)
            {
                case BrowserType.InternetExplorer:
                    {
                        InternetExplorerOptions options2 = new InternetExplorerOptions
                        {
                            ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom,
                            EnsureCleanSession = true,
                            RequireWindowFocus = true,
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true
                        };
                        _webdriver = new InternetExplorerDriver(options2);
                        break;
                    }
                case BrowserType.Firefox:
                    _webdriver = new FirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    if (options != null)
                    {
                        _webdriver = new ChromeDriver(options);
                    }
                    else
                    {
                        _webdriver = new ChromeDriver();
                    }

                    break;
            }

            _objectContainer.RegisterInstanceAs(_webdriver);
        }

        public void ScenarioTeardown()
        {
            _webdriver.Quit();
            _webdriver.Dispose();
        }
    }
}
