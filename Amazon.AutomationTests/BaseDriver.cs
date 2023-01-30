using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon.AutomationTests.Base
{
    public class BaseDriver
    {
        public IWebDriver InitChrome()
        {
            var chromeOptions = SetChromeOptions();
            Console.WriteLine("Chrome driver Created.");
            return InitLocalRun(chromeOptions);
        }

        private TimeSpan ChromeImplicitWait(IWebDriver driver)
        {
            return driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }

        private IWebDriver InitLocalRun(ChromeOptions chromeOptions)
        {
            var chromeDriver = new ChromeDriver(chromeOptions);
            ChromeImplicitWait(chromeDriver);
            return chromeDriver;
        }

        private ChromeOptions SetChromeOptions()
        {
            var options = new ChromeOptions();
            //options.AddArguments("--window-size=1920,1080");
            options.AddArguments("--start-maximized");
            options.AddArguments("--incognito");
            options.AddArguments("--verbose");
            //options.AddArguments("--headless");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--proxy-server='direct://'");
            options.AddArguments("--proxy-bypass-list=*");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--ignore-certificate-errors-spki-list");
            options.AddArguments("--ignore-certificate-errors");

            return options;
        }
    }
}