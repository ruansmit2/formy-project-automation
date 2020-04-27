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
    class Dropdown : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Dropdown_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("Dropdown")).Click();
            Assert.AreEqual("dropdown", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Using the dropdown
            _webDriver.FindElement(By.Id("dropdownMenuButton")).Click();
            _webDriver.FindElement(By.XPath("/html/body/div/div/div/a[15]")).Click();

            Assert.AreEqual("form", _webDriver.Url.Split('/').Last());
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
