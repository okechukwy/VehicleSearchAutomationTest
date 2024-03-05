using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;

namespace VehicleSearchAutomationTest.Reporting
{
   
    public class ExtentReporting
    {
        
        public ExtentReports GenerateReport(ExtentReports extent)
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





        }
    }
}
