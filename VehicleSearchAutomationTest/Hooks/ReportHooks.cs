using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
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


       /* public ExtentReports GenerateReport(ExtentReports extent)
        {
            //New Report Instance, add some environmental details to the report
            extent.AddSystemInfo("Test Environment", "<b>" + ConfigurationManager.AppSettings["Website"] + "</b>");

            //Get bin location
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var dt = DateTime.Now.ToString("dd_MMM_yyyy_HH_mm");
            var htmlReporter = new ExtentSparkReporter(path + "\\Vehicle_Automation_Test_" + dt + ".html");

            // Load reporting config for look and feel
            htmlReporter.LoadConfig(path + "\\VehicleSearchAutomationTest\\Reporting\\extent-config.xml");

            //Attach to new report instansce
            extent.AttachReporter(htmlReporter);
            return extent;





        }*/

        /* [Binding]
         class ReportHook : TechTalk.SpecFlow.Steps
         {
             private static ExtentTest featureName;
             private static ExtentTest scenario;
             private static ExtentReports extent;
             [BeforeTestRun]
             public static void InitializeReport()
             {
                 var htmlReporter = new ExtentSparkReporter(@"Location to Save");

                 extent = new ExtentReports();
                 extent.AttachReporter(htmlReporter);
             }
             [AfterTestRun]
             public static void TearDownReport()
             {
                 extent.Flush();
             }
             [AfterStep]
             public void InsertReportingSteps(ScenarioContext sc)
             {
                 var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
                 PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
                 MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                 object TestResult = getter.Invoke(sc, null);
                 if (sc.TestError == null)
                 {
                     if (stepType == "Given")
                         scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                     else if (stepType == "When")
                         scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                     else if (stepType == "Then")
                         scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                     else if (stepType == "And")
                         scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                 }
                 if (sc.TestError != null)
                 {
                     if (stepType == "Given")
                         scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                     if (stepType == "When")
                         scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                     if (stepType == "Then")
                         scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                     if (stepType == "And")
                         scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                 }
             }
             [BeforeFeature]
             public static void BeforeFeature(FeatureContext featurecontext)
             {
                 featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
             }

         }*/

    }
}
