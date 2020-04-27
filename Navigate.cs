using OpenQA.Selenium;
using NUnit.Framework;

namespace Selenium_Essential_Training
{
    class Navigate : ChromeDriverLocation
    {
        private static IWebDriver _webDriver = GetDriver(Drivers.chrome);

        [Test]
        public void Navigate_Test()
        {
            _webDriver.Url = "http://formy-project.herokuapp.com/";
        }

        [TearDown]
        public void EndTest()
        {
            _webDriver.Quit();
        }
    }
}