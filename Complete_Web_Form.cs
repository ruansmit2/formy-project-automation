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
    class Complete_Web_Form : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));

        [SetUp]
        public void Initialize()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [Test]
        public void Complete_Web_Form_Test()
        {
            //Navigate to the Complete web form page
            _webDriver.FindElement(By.LinkText("Complete Web Form")).Click();
            Assert.AreEqual("form", _webDriver.Url.Split('/').Last());

           
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/h1")));

            //Fill in form
            submitForm(_webDriver);

            //Wait for sucess page
            waitForSuccess(_webDriver);

        }

        public void submitForm(IWebDriver _webDriver)
        {
            _webDriver.FindElement(By.Id("first-name")).SendKeys("Ruan");
            _webDriver.FindElement(By.Id("last-name")).SendKeys("Smit");
            _webDriver.FindElement(By.Id("job-title")).SendKeys("SDET");
            _webDriver.FindElement(By.Id("radio-button-2")).Click();
            _webDriver.FindElement(By.Id("checkbox-1")).Click();
            _webDriver.FindElement(By.XPath("//*[@id='select-menu']/option[4]")).Click();
            _webDriver.FindElement(By.Id("datepicker")).SendKeys("04/24/1990");

            _webDriver.FindElement(By.XPath("/html/body/div/form/div/div[8]/a")).Click();
        }

        public void waitForSuccess(IWebDriver _webDriver)
        {
            IWebElement Success = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div")));
            Assert.AreEqual("The form was successfully submitted!", _webDriver.FindElement(By.XPath("/html/body/div/div")).Text);
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}

