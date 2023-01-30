using Amazon.AutomationTests.Base;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;

namespace Amazon.AutomationTests.Steps.Steps.HomePageSteps
{
    public class HomePageSteps : BaseSteps
    {
        private UrlsSettings _urlSettings;
        public HomePageSteps(IWebDriver driver, IOptions<UrlsSettings> urlSettings) : base(driver)
        {
            _urlSettings = urlSettings.Value;
        }

        public void OpenHomePage()
        {
            driver?.Navigate().GoToUrl(_urlSettings.BaseUrl);
            WaitForPageFullyLoaded();
            Console.WriteLine("[Home page] The page is opened.");
        }
    }
}
