using OpenQA.Selenium;
using VehicleSearchAutomationTest.Settings;

namespace VehicleSearchAutomationTest.ComponentHelper
{
    public class TextBoxHelper
    {
        protected readonly IWebDriver _driver = default!;
        private static IWebElement? element;
        
        
        private readonly GenericHelper? genericHelper;

        public void TypeInTextBox(By locator, string text)
        {
            element = GetElement(locator);
            element.SendKeys(text);

        }

        public void ClearTextBox(By locator)
        {
            element = GetElement(locator);
            element.Clear();

        }

        public IWebElement GetElement(By locator)
        {
            #pragma warning disable CS8602
            if (genericHelper.IsElemetPresent(locator))
                return _driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }
    }
}
