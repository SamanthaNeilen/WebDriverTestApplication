using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WebDriverTestApplication.Tests
{
    [TestClass]
    public class WindowsTests
    {
        // Automation Id's are found using the inspect.exe tool (https://msdn.microsoft.com/en-us/library/windows/desktop/dd318521(v=vs.85).aspx)
        private const string BUTTON_5_AUTOMATION_ID = "135";
        private const string BUTTON_ADD_AUTOMATION_ID = "93";
        private const string BUTTON_EQUALS_AUTOMATION_ID = "121";
        private const string RESULT_AUTOMATION_ID = "150";

        [TestMethod]
        public void Test_Windows_Calculator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "\\Assets\\Winium.Desktop.Driver.exe";
            var winiumdriverProcess = Process.Start(startInfo);

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"C:/windows/system32/calc.exe");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var window = driver.FindElementByClassName("CalcFrame");
            
            var button5 = window.FindElement(By.Id(BUTTON_5_AUTOMATION_ID));
            button5.Click();

            var buttonPlus = window.FindElement(By.Id(BUTTON_ADD_AUTOMATION_ID));
            buttonPlus.Click();

            button5.Click();

            var buttonEquals = window.FindElement(By.Id(BUTTON_EQUALS_AUTOMATION_ID));
            buttonEquals.Click();
            
            var resultTextElement = window.FindElement(By.Id(RESULT_AUTOMATION_ID));
            Assert.AreEqual("10", resultTextElement.GetAttribute("Name"));

            driver.Close();
            driver.Dispose();
            winiumdriverProcess.CloseMainWindow();
            winiumdriverProcess.Dispose();
        }


        [TestMethod]
        public void Test_WPF_Addition()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Assets\\Winium.Desktop.Driver.exe";
            var winiumdriverProcess = Process.Start(startInfo);

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\..\..\..\WebDriverTestApplication.WPF\bin\Debug\WebDriverTestApplication.WPF.exe");
            var driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            var window = driver.FindElementById("Wpf test app");

            var amount1Edit = window.FindElement(By.Id("txtFirstAmount"));
            amount1Edit.SendKeys("5");

            var amount2Edit = window.FindElement(By.Id("txtSecondAmount"));
            amount2Edit.SendKeys("10");

            var buttonAdd = window.FindElement(By.Id("btnAdd"));
            buttonAdd.Click();

            var resultLabel = window.FindElement(By.Id("lblResult"));
            Assert.AreEqual("15", resultLabel.GetAttribute("Name"));

            driver.Close();
            driver.Dispose();
            winiumdriverProcess.CloseMainWindow();
            winiumdriverProcess.Dispose();
        }
    }
}

