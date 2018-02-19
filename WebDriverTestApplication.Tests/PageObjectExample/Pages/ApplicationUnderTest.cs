using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;

namespace WebDriverTestApplication.Tests.PageObjectExample.Pages
{
    public class ApplicationUnderTest
    {
        private readonly IWebDriver _driver;

        public ApplicationUnderTest(TestContext testContext)
        {
            string browserIdentifier = GetBrowserIdentifer(testContext);
            _driver = StartWebdriver(browserIdentifier);
        }

        public CustomerCreatePage NavigateToCustomerCreate()
        {
            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["ApplicationStartUrl"]);
            return new CustomerCreatePage(_driver);
        }

        public void CloseApplication()
        {
            _driver.Close();
            _driver.Dispose();
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

        private string GetBrowserIdentifer(TestContext testContext)
        {
            var browserIdentifier = "Chrome";
            if (testContext.DataRow != null)
            {
                browserIdentifier = testContext.DataRow[0].ToString();
            }

            return browserIdentifier;
        }
    }
}
