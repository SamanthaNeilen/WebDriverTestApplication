using OpenQA.Selenium;

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
    }
}
