using OpenQA.Selenium;

namespace VehicleSearchAutomationTest.Pages
{
    public class CazooSearchResultPage : BasePage
    {
        private IWebDriver driver;
        public static By CarMake = By.XPath("//body/div[@id='__next']/div[1]//div[1]/h1[1]");  
        public static By CarRegistration = By.XPath("//body/div[@id='__next']/div[1]/div[1]/div[1]/h2[2]"); 
        public static By MileageField = By.XPath("//body/div[@id='__next']/form[1]/div[1]//input[1] "); 

        public CazooSearchResultPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }

        public bool GetCarMake(string carMake)
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, CarMake, 5);
            string elementText = driver.FindElement(CarMake).Text;
            if (elementText.Contains(carMake))
            {
                return true;

            }
            else
            {
                return false;

            }            
        }

        public bool GetCarRegistration(string carReg)
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, CarRegistration, 5);
            string elementText = driver.FindElement(CarRegistration).Text;
            if (elementText.Contains(carReg))
             {
                return true;
             }else
                
             return false;
        }

        public bool GetCarModel(string model)
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, CarRegistration, 5);
            string elementText = driver.FindElement(CarRegistration).Text;
            if (elementText.Contains(model))
                return true;
            return false;
        }

        public void EnterMilage(string num)
        {
            WebElementExtensions.SafeWaitToBeVisible(_driver, MileageField, 5);
            driver.FindElement(MileageField).SendKeys(num);   

        }

    }
}
