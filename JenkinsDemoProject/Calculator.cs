using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;

namespace JenkinsDemoProject
{
    public class Calculator
    {
        public static WindowsDriver<WindowsElement> Session;
        ExtentTest test;

        [SetUp]
        public void Setup()
        {
            
            var fileName = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";

            //start winAppDriver
            ProcessStartInfo startInfo = new ProcessStartInfo(fileName);
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(startInfo);

            //Intialize session
            var options = new AppiumOptions();
            options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            options.AddAdditionalCapability("deviceName", "WindowsPC");
            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        }

        [TestCase("Two", "Two", "Display is 4")]
        public void TestAddTwoNumbers(string firstNo, string secondNo, string expectedResult)
        {
            try
            {
                const string addButton = "Plus";
                const string equalsButton = "Equals";
                const string actualResultsTextBox = "CalculatorResults";

                test = ExtentReporter.CreateTest("First Test");
                Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Session.Manage().Window.Maximize();
                test.Info("Executing test");
                Session.FindElementByName(firstNo).Click();
                Session.FindElementByName(addButton).Click();
                Session.FindElementByName(secondNo).Click();
                Session.FindElementByName(equalsButton).Click();
                var actualResults = Session.FindElementByAccessibilityId(actualResultsTextBox);
                Assert.AreEqual(actualResults.Text, expectedResult);
                ExtentReporter.PassTest(test);
            }
            catch (Exception)
            {
                ExtentReporter.LogFailure(test);
            }
        }

        [TearDown]
        public void TestCleanup()
        {
            ExtentReporter.flushreport();
            Session.Quit();
        }
    }
}