using AventStack.ExtentReports;
using BoDi;
using System.Configuration;
using VehicleSearchAutomationTest.Reporting;

namespace VehicleSearchAutomationTest.Hooks
{
    //[Binding]
    public static class ReportHooks
    {
        // These hooks use the Extent Reports library for Reporting purposes
        // See here for more details - http://extentreports.com/docs/versions/3/net/

        public static ExtentReports extent;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void InstantiateDriverSetup(IObjectContainer objectContainer)
        {
            // New Report Instance, add some environmental details to the report
            ExtentReporting er = new ExtentReporting();
            extent = er.GenerateReport(new ExtentReports());
        }

        [BeforeScenario()]
        public static void BeforeScenario()
        {
            // Create a new test for every Specflow Scenario
            test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title)
                .AssignCategory(FeatureContext.Current.FeatureInfo.Title)
                .AssignCategory(FeatureContext.Current.FeatureInfo.Tags[0])
                .CreateNode("Test Steps")
                .AssignAuthor("AutoTester");
        }

        [AfterStep()]
        public static void AfterStep()
        {
            // Create a new log for every Specflow step
            //var errorMessage = TestContext.CurrentContext.Result.Message;
            Status stepStatus = new Status();
            string stepLogText = ScenarioContext.Current.StepContext.StepInfo.StepInstance.Keyword + " " + ScenarioContext.Current.StepContext.StepInfo.Text;

            if (ScenarioContext.Current.TestError == null)
            {
                stepStatus = Status.Pass;

            }
            else
            {
                stepStatus = Status.Fail;
                stepLogText = stepLogText + " : " + "<pre>" + ScenarioContext.Current.TestError.Message + "</pre>";

            }

            test.Log(stepStatus, stepLogText);
        }

        [AfterTestRun()]
        public static void AfterTestRun()
        {
            // Write the log away and create the output file
            extent.Flush();
            extent.RemoveTest(test);
        }

    }
      
}
