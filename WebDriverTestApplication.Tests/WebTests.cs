﻿using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using WebDriverTestApplication.Shared.Resources;

namespace WebDriverTestApplication.Tests
{
    [TestClass]
    public class WebTests
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        protected string StartUrl = ConfigurationManager.AppSettings["ApplicationStartUrl"];

        [TestMethod, DataSource("Browsers")]
        public void WebTest_Selenium_TestForm()
        {
            var browserIdentifier = "Chrome";
            if (TestContext.DataRow != null)
            {
                browserIdentifier = TestContext.DataRow[0].ToString();
            }

            using (var driver = StartWebdriver(browserIdentifier))
            {
                driver.Navigate().GoToUrl(new Uri(StartUrl));

                var nameTextBox = driver.FindElement(By.Id("Name"));
                nameTextBox.SendKeys("Some Name");

                var submitButton = driver.FindElement(By.TagName("button"));
                submitButton.Click();

                var header = driver.FindElement(By.Id("addCustomerHeader"));
                Assert.IsTrue(header.Displayed);

                Assert.AreEqual(0, driver.FindElements(By.Id("Name-error")).Count);

                var expectedEmailvalidationMessage = string.Format(Messages.FieldRequired, Labels.EmailAddress);
                var validationMessages = driver.FindElements(By.CssSelector(".field-validation-error"));
                Assert.IsTrue(validationMessages.Any(element => element.Displayed && ChildSpanContainsExpectedText(element, expectedEmailvalidationMessage)));

                driver.Close();
            }
        }

        private static bool ChildSpanContainsExpectedText(IWebElement element, string expectedEmailvalidationMessage)
        {
            return element.FindElement(By.TagName("span")).Text.Equals(expectedEmailvalidationMessage);
        }

        private IWebDriver StartWebdriver(string browserIdentifier)
        {
            switch (browserIdentifier)
            {
                case "IE":
                    return new InternetExplorerDriver("Assets");
                case "Firefox":
                    return new FirefoxDriver("Assets");
                case "Chrome":
                    return new ChromeDriver("Assets");
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
