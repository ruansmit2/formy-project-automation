using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Linq;

namespace Selenium_Essential_Training
{
    class Autocomplete : ChromeDriverLocation
    {

        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Autocomplete_Test()
        {
            //Navigate to the autocomplete page 
            _webDriver.FindElement(By.LinkText("Autocomplete")).Click();
            Assert.AreEqual("autocomplete", _webDriver.Url.Split('/').Last());

            //Click in textbox "Full Name" and click on the Button
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _webDriver.FindElement(By.XPath("//*[@class='form-control pac-target-input']")).SendKeys("2B Petersen Street");
            _webDriver.FindElement(By.XPath("//*[@class='pac-item'][2]")).Click();

        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
