using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Essential_Training
{
    class Switch_Window : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Windows_Test()
        {
            //Navigate to the autocomplete page 
            _webDriver.FindElement(By.LinkText("Switch Window")).Click();
            Assert.AreEqual("switch-window", _webDriver.Url.Split('/').Last());

            //Click on "Open new tab"
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string CurrentHandle = _webDriver.CurrentWindowHandle;
            _webDriver.FindElement(By.Id("new-tab-button")).Click();


            string NewHandle = _webDriver.CurrentWindowHandle;

            _webDriver.SwitchTo().Window(CurrentHandle);
            Assert.AreEqual("switch-window", _webDriver.Url.Split('/').Last());
        }

        [Test]
        public void Alert_Test()
        {
            //Navigate to the autocomplete page 
            _webDriver.FindElement(By.LinkText("Switch Window")).Click();
            Assert.AreEqual("switch-window", _webDriver.Url.Split('/').Last());

            //Click on "Open new tab"
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _webDriver.FindElement(By.Id("alert-button")).Click();
            
            //Wait for alert and get text
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string AlertText = _webDriver.SwitchTo().Alert().Text;
            Assert.AreEqual("This is a test alert!", AlertText);

            //Click on OK
            _webDriver.SwitchTo().Alert().Accept();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
