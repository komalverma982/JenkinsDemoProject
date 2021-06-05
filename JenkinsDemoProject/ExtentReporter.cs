using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace JenkinsDemoProject
{
    public class ExtentReporter
    {
        protected static ExtentTest _test;
        private static ExtentReports _extent = new ExtentReports();

        public static ExtentTest CreateTest(string TestName)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var ReportPath = Path.Combine(path, "Reports", $"Automation_Report_{DateTime.Now.ToString("yyyymmddhhmmssffff", CultureInfo.CurrentCulture)}");

            var htmlReporter = new ExtentHtmlReporter(Path.Combine(ReportPath, "Extent.html"));

            _extent.AddSystemInfo("Environment", "Test");
            _extent.AddSystemInfo("User Name", "Komal");
            _extent.AttachReporter(htmlReporter);
            _test = _extent.CreateTest(TestName);
            return _test;
        }

        public static void flushreport()
        {
            _extent.Flush();
        }

        public static void PassTest(ExtentTest test)
        {
            test.Pass("Results are as expected");
        }
        public static ExtentTest CreateNode(string info)
        {
            return _test.CreateNode(info);
        }

        public static void LogFailure(ExtentTest test)
        {
            test.Log(Status.Fail, "Result are not as expected");
        }
    }
}

