using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace VehicleSearchAutomationTest
{
    public static class WebElementExtensions
    {

        private static WebDriverWait wait;
        public static IWebElement SafeWaitToBeVisible(this IWebDriver driver, By locator, int timeInSecs)
        {
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSecs));
                return wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (ElementNotVisibleException)
            {
                return null;
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }





        public static Func<IWebDriver, bool> ElementIsVisible(By by)
        {
            return driver => {


                try
                {
                    return driver.FindElement(by).Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };

        }



    }
}
