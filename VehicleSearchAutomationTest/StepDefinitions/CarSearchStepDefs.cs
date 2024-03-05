using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using VehicleSearchAutomationTest.ComponentHelper;
using VehicleSearchAutomationTest.ExcelReader;
using VehicleSearchAutomationTest.Pages;

namespace VehicleSearchAutomationTest.StepDefinitions
{
    [Binding]
    public class CarSearchStepDefs : BaseStepDefs<CazooCarSearchPage>
    {
        private readonly ScenarioContext _scenarioContext;
        private CarValuation carValuation;
        private CazooSearchResultPage cazooSearchResultPage;
        private IWebDriver _Driver;

        public CarSearchStepDefs(IWebDriver driver, ScenarioContext scenaroContext)
        {
            _Driver = driver;
            _Page = new CazooCarSearchPage(_Driver);
            cazooSearchResultPage = new CazooSearchResultPage(_Driver);
            carValuation = new CarValuation();
            _scenarioContext = scenaroContext;

        }

        [Given(@"I navigate to the Cazoo home page with url ""([^""]*)""")]
        public void GivenINavigateToTheCazooHomePageWithUrl(string url)
        {
            _Driver.Navigate().GoToUrl(url);    
        }

        [Given(@"I accept the cookie")]
        public void GivenIAcceptTheCookie() 
        {
            _Page.AcceptCookies();
        }


        [When(@"I input a car with the ""([^""]*)"" in the serach field")]
        public void WhenIInputACarWithTheInTheSerachField(string rEGISTRATION)
        {
            _Page.EnterVehicleRegistration(rEGISTRATION);
        }


        /*[When(@"I enter the milage of ""([^""]*)""")]
        public void WhenIEnterTheMilageOf(string p0)
        {
            _Page.
        }
        */

        
        [When(@"I serach for the details")]
        public void WhenISerachForTheDetails()
        {
            _Page.SearchVehicleDetails();   
        }

        [Then(@"I will see a car with the following details ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""")]
        public void ThenIWillSeeACarWithTheFollowingDetailsAnd(string reg, string make, string model)
        {
            cazooSearchResultPage.GetCarRegistration(reg);
            _scenarioContext.Add("CarRegistration", reg);
            reg = _scenarioContext.Get<string>("CarRegistration");
            carValuation.WriteCsvToFile(reg);

            cazooSearchResultPage.GetCarMake(make);
            _scenarioContext.Add("CarMake", make);
            make = _scenarioContext.Get<string>("CarMake");
            carValuation.WriteCsvToFile(make);

            cazooSearchResultPage.GetCarModel(model);
            _scenarioContext.Add("CarMode", model);
            model = _scenarioContext.Get<string>("CarMode");
            carValuation.WriteCsvToFile(model);

        }






    }
}