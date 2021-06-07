using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;

namespace JenkinsDemoProject
{
    public class ExtentReporter
    {
        protected static ExtentTest _test;
        private static ExtentReports _extent = new ExtentReports();
        
        /// <summary>
        /// Method to Create Test
        /// </summary>
        /// <param name="TestName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method to flush the report
        /// </summary>
        public static void flushreport()
        {
            _extent.Flush();
        }

        /// <summary>
        /// Method to log test as passed
        /// </summary>
        /// <param name="test"></param>
        public static void PassTest(ExtentTest test)
        {
            test.Pass("Results are as expected");
        }

        /// <summary>
        /// Method to log failure
        /// </summary>
        /// <param name="test"></param>
        public static void LogFailure(ExtentTest test)
        {
            test.Log(Status.Fail, "Result are not as expected");
        }
    }
}

