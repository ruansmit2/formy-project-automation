using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System;

namespace Selenium_Essential_Training
{
    class Keyboard_Mouse_Input : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);
        
        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Keyboard_Mouse_Test()
        {
            //Navigate to the Keyboard and Mouse Input page 
            _webDriver.FindElement(By.LinkText("Key and Mouse Press")).Click();
            Assert.AreEqual("keypress", _webDriver.Url.Split('/').Last());

            //Click in textbox "Full Name" and click on the Button
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.FindElement(By.Id("name")).SendKeys("Ruan Smit");
            _webDriver.FindElement(By.CssSelector("#button"));
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
