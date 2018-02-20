using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Linq;
using WebDriverTestApplication.Shared.Resources;

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

        public bool ShowsValidationError(string fieldName)
        {
            return _driver.FindElements(By.Id($"{fieldName}-error")).Any();
        }
        

        public bool ShowsRequiredFieldValidationError(string fieldLabel)
        {
            var expectedEmailvalidationMessage = string.Format(Messages.FieldRequired, fieldLabel);
            var validationMessages = _driver.FindElements(By.CssSelector(".field-validation-error"));
            return validationMessages.Any(element => element.Displayed && ChildSpanContainsExpectedText(element, expectedEmailvalidationMessage));
        }

        private bool ChildSpanContainsExpectedText(IWebElement element, string expectedEmailvalidationMessage)
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
