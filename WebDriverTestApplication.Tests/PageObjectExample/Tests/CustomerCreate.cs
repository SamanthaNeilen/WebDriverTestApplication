using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverTestApplication.Shared.Resources;
using WebDriverTestApplication.Tests.PageObjectExample.Pages;

namespace WebDriverTestApplication.Tests.PageObjectExample.Tests
{
    [TestClass]
    public class CustomerCreate
    {
        private ApplicationUnderTest _applicationUnderTest;

        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        [TestInitialize]
        public void Initialize()
        {

            _applicationUnderTest = new ApplicationUnderTest(TestContext);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _applicationUnderTest.CloseApplication();
        }


        [TestMethod, DataSource("Browsers")]
        public void WebTest_Selenium_CustomerCreate_PageObject_Example_Test()
        {
            //ARRANGE
            var customerPage = _applicationUnderTest.NavigateToCustomerCreate();

            //ACT
            customerPage.SetNameText("Some Name");
            customerPage.ClickSubmit();

            //ASSERT
            Assert.IsTrue(customerPage.IsCurrentPage());
            Assert.IsFalse(customerPage.ShowsValidationError("Name"));
            Assert.IsFalse(customerPage.ShowsValidationError("EmailAddress"));
            Assert.IsFalse(customerPage.ShowsRequiredFieldValidationError(Labels.EmailAddress));
        }
    }
}
