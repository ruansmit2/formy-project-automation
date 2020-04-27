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
    class Radio_CheckBox : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Radio_CheckBox_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("Radio Button")).Click();
            Assert.AreEqual("radiobutton", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            //Click on radio Buttons
            _webDriver.FindElement(By.XPath("/html/body/div/div[2]/input")).Click();
            _webDriver.FindElement(By.XPath("/html/body/div/div[3]/input")).Click();

            _webDriver.Url = "http://formy-project.herokuapp.com/checkbox";

            Assert.AreEqual("checkbox", _webDriver.Url.Split('/').Last());

            //Select by Xpath and ID 
            _webDriver.FindElement(By.Id("checkbox-1")).Click();
            _webDriver.FindElement(By.Id("checkbox-2")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
