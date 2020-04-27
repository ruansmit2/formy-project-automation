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
    class Drag_Drop : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Drag_Drop_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("Drag and Drop")).Click();
            Assert.AreEqual("dragdrop", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement image = _webDriver.FindElement(By.Id("image"));

            IWebElement box = _webDriver.FindElement(By.Id("box"));

            Actions actions = new Actions(_webDriver);
            actions.DragAndDrop(image, box).Build().Perform();

        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
