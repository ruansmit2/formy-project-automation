using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Selenium_Essential_Training
{
    class Modal : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Modal_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("Modal")).Click();
            Assert.AreEqual("modal", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _webDriver.FindElement(By.Id("modal-button")).Click();

            //Wait for element to be used
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='exampleModalLabel']")));

            //Assert modal poped up
            string ModalTitle = _webDriver.FindElement(By.XPath("//*[@id='exampleModalLabel']")).Text;
            Assert.AreEqual("Modal title", ModalTitle);

            //Close modal
            _webDriver.FindElement(By.Id("ok-button")).Click();

        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
