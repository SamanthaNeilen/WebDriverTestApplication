using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace WebDriverTestApplication.Tests
{
    [TestClass]
    public class WindowsTests
    {
        [TestMethod]
        public void Test_Windows_Calculator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\Assets\\Winium.Desktop.Driver.exe";
            var winiumdriverProcess = Process.Start(startInfo);

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/windows/system32/calc.exe");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var numpad = driver.FindElementById("NumberPad");
            var operations = driver.FindElementById("StandardOperators");

            var button5 = numpad.FindElement(By.Id("num5Button"));
            button5.Click();

            var buttonPlus = operations.FindElement(By.Id("plusButton"));
            buttonPlus.Click();
            
            button5.Click();
            
            var buttonEquals = operations.FindElement(By.Id("equalButton"));
            buttonEquals.Click();

            var resultArea = driver.FindElementById("CalculatorResults");
           // Assert.AreEqual("10", resultArea.Text);

            var resultText = resultArea.FindElement(By.Id("textContainer"));
            Assert.AreEqual("10", resultText.Text);

            driver.Close();
            driver.Dispose();
            winiumdriverProcess.Close();
            winiumdriverProcess.Dispose();
        }
    }
}
