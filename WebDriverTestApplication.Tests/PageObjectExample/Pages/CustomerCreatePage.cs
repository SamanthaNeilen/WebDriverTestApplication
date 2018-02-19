using OpenQA.Selenium;
using System;
using System.Linq;
using WebDriverTestApplication.Shared.Resources;

namespace WebDriverTestApplication.Tests.PageObjectExample.Pages
{
    public class CustomerCreatePage
    {
        private readonly IWebDriver _driver;

        public CustomerCreatePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void SetNameText(string input)
        {
            var nameTextBox = _driver.FindElement(By.Id("Name"));
            nameTextBox.SendKeys(input);
        }

        public void ClickSubmit()
        {
            var submitButton = _driver.FindElement(By.TagName("button"));
            submitButton.Click();
        }

        public bool IsCurrentPage()
        {
            var header = _driver.FindElement(By.Id("addCustomerHeader"));
            return header.Displayed;
        }
        public bool ShowsValidationError(string fieldName)
        {
            return _driver.FindElements(By.Id($"{fieldName}-error")).Any();
        }

        public bool ShowsRequiredValidationError(string fieldName)
        {
            return _driver.FindElements(By.Id($"{fieldName}-error")).Any();
        }

        public  bool ShowsRequiredFieldValidationError(string fieldLabel)
        {
            var expectedEmailvalidationMessage = string.Format(Messages.FieldRequired, fieldLabel);
            var validationMessages = _driver.FindElements(By.CssSelector(".field-validation-error"));
            return validationMessages.Any(element => element.Displayed && ChildSpanContainsExpectedText(element, expectedEmailvalidationMessage));
        }

        private bool ChildSpanContainsExpectedText(IWebElement element, string expectedEmailvalidationMessage)
        {
            return element.FindElement(By.TagName("span")).Text.Equals(expectedEmailvalidationMessage);
        }

        
    }
}
