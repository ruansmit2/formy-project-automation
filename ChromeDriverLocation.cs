using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace Selenium_Essential_Training
{

    public enum Drivers
    {
        chrome
    }
    public class ChromeDriverLocation
    {
        internal static IWebDriver GetDriver(Drivers driver)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var relativePath = @"..\..\bin\Debug";
            var chromeDriverPath = Path.GetFullPath(Path.Combine(outPutDirectory, relativePath));
            return new ChromeDriver(chromeDriverPath);
        }
    }
}

