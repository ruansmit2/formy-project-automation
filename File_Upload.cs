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
    class File_Upload : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void File_Upload_Test()
        {
            //Navigate to the Modal page 
            _webDriver.FindElement(By.LinkText("File Upload")).Click();
            Assert.AreEqual("fileupload", _webDriver.Url.Split('/').Last());

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Using the file selector
            _webDriver.FindElement(By.Id("file-upload-field")).SendKeys(@"C:\Users\Administrator\Desktop\file.txt");

        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}
