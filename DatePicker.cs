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
    class DatePicker : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void DatePicker_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("Datepicker")).Click();
            Assert.AreEqual("datepicker", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Using the popup pick a date
            _webDriver.FindElement(By.Id("datepicker")).Click();
            _webDriver.FindElement(By.XPath("/html/body/div[2]/div[1]/table/tbody/tr[1]/td[4]")).Click();

            _webDriver.Navigate().Refresh();

            _webDriver.FindElement(By.Id("datepicker")).SendKeys("04/24/1990");
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
