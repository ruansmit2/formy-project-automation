using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;
using OpenQA.Selenium.Interactions;

namespace Selenium_Essential_Training
{
    class Scroll : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Scroll_Test()
        {
            //Navigate to the autocomplete page 
            _webDriver.FindElement(By.LinkText("Page Scroll")).Click();
            Assert.AreEqual("scroll", _webDriver.Url.Split('/').Last());

            //Click in textbox "Full Name" and "Date" and add text
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement name = _webDriver.FindElement(By.XPath("//*[@id='name']"));
            IWebElement date = _webDriver.FindElement(By.XPath("//*[@id='date']"));

            //Scroll to element
            Actions actions = new Actions(_webDriver);
            actions.MoveToElement(name);


            //Send text to the textboxes
            name.SendKeys("Ruan Smit");
            date.SendKeys("01/01/2020");
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
